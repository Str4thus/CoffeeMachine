﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StateData", menuName = "StateData")]
public class StateData : ScriptableObject
{
    private DrinkData drink;
    public DrinkData Drink {
        get {
            return drink;
        }

        // Update the money display automatically
        set {
            if (value)
                GameManager.Instance.moneyDisplay.UpdateDisplay(value.price);
            else
                GameManager.Instance.moneyDisplay.UpdateDisplay(0);

            drink = value;
        }
    }

    [Header("Start Resources")]
    [SerializeField] private float coffeePowder = 1000f; // gramms
    [SerializeField] private float milkPowder = 1000f; // gramms
    [SerializeField] private int milkPortions = 100;
    [SerializeField] private int sugarCubes = 100;

    [Header("Minimum Required Resources")]
    [SerializeField] private float minCoffeePowder = 5f; // gramms
    [SerializeField] private float minMilkPowder = 5f; // gramms
    [SerializeField] private int minMilkPortions = 1;
    [SerializeField] private int minSugarCubes = 1;

    [Header("Odd Money")]
    [SerializeField] private int twoEuros;
    [SerializeField] private int oneEuros;
    [SerializeField] private int fiftyCents;
    [SerializeField] private int twentyCents;
    [SerializeField] private int tenCents;

    private float paidMoney = 0f;
    public float PaidMoney => paidMoney;

    private Dictionary<float, int> oddMoney = new Dictionary<float, int>();
    private Dictionary<float, int> oddMoneyToReturn = new Dictionary<float, int>();
    private Dictionary<float, int> insertedMoney = new Dictionary<float, int>();

    private bool drinkCreated = false;


    public void OnEnable() {
        oddMoney[.1f] = tenCents;
        oddMoney[.2f] = twentyCents;
        oddMoney[.5f] = fiftyCents;
        oddMoney[1f] = oneEuros;
        oddMoney[2f] = twoEuros;
    }


    public void Reset() {
        drink = null;
        insertedMoney.Clear();
        oddMoneyToReturn.Clear();
        paidMoney = 0f;
        drinkCreated = false;

        GameManager.Instance.moneyDisplay.UpdateDisplay(0f);
        GameManager.Instance.drinkSelection.SelectPlaceholder();
    }
    
    public void CreateDrink() {
        GameManager.Instance.CreateDrinkGameObject(Drink);
        drinkCreated = true;
    }

    // Resources
    public bool HasSufficientResources() {
        return coffeePowder >= Drink.neededCoffeePowder
            && milkPowder >= Drink.neededMilkPowder
            && sugarCubes >= Drink.desiredSugarCubes
            && milkPortions >= Drink.desiredMilkPortions;
    }

    public void UseRequiredResources() {
        coffeePowder -= Drink.neededCoffeePowder;
        milkPowder -= Drink.neededMilkPowder;
        sugarCubes -= Drink.desiredSugarCubes;
        milkPortions -= Drink.desiredMilkPortions;
    }

    public bool ResourcesAboveMinimumRequirement() {
        return coffeePowder >= minCoffeePowder
            && milkPowder >= minMilkPowder
            && sugarCubes >= minSugarCubes
            && milkPortions >= minMilkPortions;
    }

    // Payment
    public void Pay(float amount) {
        // Keep track of inserted money
        insertedMoney.TryGetValue(amount, out var currentCount);
        insertedMoney[amount] = currentCount + 1;

        oddMoney[amount]++; // Add inserted money to odd money

        GameManager.Instance.moneyDisplay.SubtractAmount(amount);
        paidMoney += amount;
    }
    
    public void ReturnMoney() {
        if (drinkCreated) { // Return odd money
            foreach (float key in oddMoneyToReturn.Keys) {
                oddMoney[key] -= oddMoneyToReturn[key]; // Subtract the returned pieces from the others
            }
            oddMoneyToReturn.Clear();
        } else { // Cannot change -> return inserted money
            foreach (float key in insertedMoney.Keys) {
                oddMoney[key] -= insertedMoney[key]; // Subtract the returned pieces from the others
            }
            insertedMoney.Clear();
        }
    }

    public bool HasPaidEnough() {
        return PaidMoney >= drink.price;
    }

    public bool ReceivesOddMoney() {
        return PaidMoney > drink.price;
    }

    public bool IsAmountChangable() {
        double amountToChange = Math.Round(Mathf.Abs(drink.price - PaidMoney), 1);
        float changeableAmount = 0f;

        float[] moneyPieces = new float[] { 2f, 1f, .5f, .2f, .1f };
        
        for (int i = 0; i < moneyPieces.Length; i++) {
            if (amountToChange > 0f) {
                int optimalPieces = (int)Mathf.Floor((float) amountToChange / moneyPieces[i]); // Calculate the optimal number of money piece X to change
                if (optimalPieces > 0) {
                    int amountOfPieces = Mathf.Min(optimalPieces, oddMoney[moneyPieces[i]]); // Take the optimal number of pieces, or the rest of the pieces that are available

                    changeableAmount += moneyPieces[i] * amountOfPieces;
                    oddMoneyToReturn[moneyPieces[i]] = amountOfPieces;
                }
            } else {
                break;
            }
            
            amountToChange -= changeableAmount;
            amountToChange = Math.Round(amountToChange, 1);
            changeableAmount = 0f;
        }
        
        return amountToChange == 0f;
    }
}
