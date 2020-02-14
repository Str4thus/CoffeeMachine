using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q0
public class ChooseDrinkState : State
{
    /*
     * possibleNextStates:
     * 0 - q1 (EnoughResources)
     * 1 - q6 (InsufficientResources)
     */
    public override State CheckForTransition() {
        if (stateData.drink.Length == 0)
            return null;

        if (stateData.coffeePowder > 10)
            return possibleNextStates[0]; // q1

        return possibleNextStates[1]; // q6
    }

    public override void SelectDrink(string drink) {
        Debug.Log("Selected " + drink);
        stateData.drink = drink;
    }
}
