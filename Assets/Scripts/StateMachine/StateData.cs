using System;
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

    [SerializeField] private float coffeePowder = 1000f; // gramms
    [SerializeField] private float milkPowder = 1000f; // gramms
    [SerializeField] private int milkPortions = 100;
    [SerializeField] private int sugarCubes = 100;

    [SerializeField] private float paidMoney = 0f;
    public float PaidMoney => paidMoney;

    // Odd Money
    [SerializeField] private int twoEuros = 10;
    [SerializeField] private int oneEuros = 10;
    [SerializeField] private int fiftyCents = 10;
    [SerializeField] private int twentyCents = 10;
    [SerializeField] private int tenCents = 10;
    
    private Dictionary<float, int> oddMoney = new Dictionary<float, int>();

    public void OnEnable() {
        oddMoney[0.1f] = tenCents;
        oddMoney[0.2f] = twentyCents;
        oddMoney[0.5f] = fiftyCents;
        oddMoney[1f] = oneEuros;
        oddMoney[2f] = twoEuros;
    }

    public bool HasSufficientResources() {
        return coffeePowder >= Drink.neededCoffeePowder
            && milkPowder >= Drink.neededMilkPowder
            && sugarCubes >= Drink.desiredSugarCubes
            && milkPortions >= Drink.desiredMilkPortions;
    }

    public bool IsPaymentSucessful() {
        return PaidMoney >= drink.price && IsAmountIsChangable();
    }
    
    public void Pay(float amount) {
        oddMoney[amount]++; // Add inserted money to odd money

        GameManager.Instance.moneyDisplay.SubtractAmount(amount);
        paidMoney += amount;
    }
    
    private bool IsAmountIsChangable() {
        double amountToChange = Math.Round(Mathf.Abs(drink.price - PaidMoney), 1);
        float changeableAmount = 0f;

        float[] moneyPieces = new float[] { 2f, 1f, .5f, .2f, .1f };

        for (int i = 0; i < moneyPieces.Length; i++) {
            if (amountToChange > 0f) {
                int optimalPieces = (int)Mathf.Floor((float) amountToChange / moneyPieces[i]);
                if (optimalPieces > 0) {
                    changeableAmount += moneyPieces[i] * Mathf.Min(optimalPieces, oddMoney[moneyPieces[i]]);
                }
            } else {
                break;
            }

            Debug.Log(amountToChange);
            Debug.Log(changeableAmount);
            amountToChange -= changeableAmount;
            amountToChange = Math.Round(amountToChange, 1);
            changeableAmount = 0f;
        }

        Debug.Log("---");
        Debug.Log(amountToChange);
        Debug.Log("---");
        Debug.Log(amountToChange == 0f);

        return amountToChange == 0f;
    }
}
