using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q0
public class ChooseDrinkState : State
{
    [Header("Required")]
    [SerializeField]
    private DrinkSelector drinkSelector = null;

    public override StateName StateName { get { return StateName.ChooseDrink; } }

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        drinkSelector.SelectPlaceholder();
        drinkSelector.SetDropdownActive(true);
    }

    public override void Exit() {
        base.Exit();
        drinkSelector.SetDropdownActive(false);
    }

    /*
     * possibleNextStates:
     * 0 - q1 (EnoughResources)
     * 1 - q6 (InsufficientResources)
     */
    public override State CheckForTransition() {
        if (stateData.drink == null)
            return null;

        if (stateData.HasSufficientResources())
            return possibleNextStates[0]; // q1

        return possibleNextStates[1]; // q6
    }

    public override void SelectDrink(DrinkData drink) {
        stateData.drink = drink;
    }
}
