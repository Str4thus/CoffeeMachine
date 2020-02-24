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

    public bool HasSufficientResources() {
        return coffeePowder >= Drink.neededCoffeePowder
            && milkPowder >= Drink.neededMilkPowder
            && sugarCubes >= Drink.desiredSugarCubes
            && milkPortions >= Drink.desiredMilkPortions;
    }

    public void Pay(float amount) {
        //IsAmountIsChangable();

        GameManager.Instance.moneyDisplay.SubtractAmount(amount);
        paidMoney += amount;
    }

    private void IsAmountIsChangable() {
        // make sure, that the machine can return the correct amount of odd money
    }
}
