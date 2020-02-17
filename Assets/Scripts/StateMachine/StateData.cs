using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StateData", menuName = "StateData")]
public class StateData : ScriptableObject
{
    public DrinkData drink;
    public float coffeePowder = 1000f; // gramms
    public float milkPowder = 1000f; // gramms
    public int milkPortions = 100;
    public int sugarCubes = 100;

    public float costs = 0f;
    public float paidMoney = 0f;

    // Odd Money
    public int twoEuros = 10;
    public int oneEuros = 10;
    public int fiftyCents = 10;
    public int twentyCents = 10;
    public int tenCents = 10;

    public bool HasSufficientResources() {
        Debug.Log(drink);

        return coffeePowder >= drink.neededCoffeePowder
            && milkPowder >= drink.neededMilkPowder
            && sugarCubes >= drink.desiredSugarCubes
            && milkPortions >= drink.desiredMilkPortions;
    }
}
