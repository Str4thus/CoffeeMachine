using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q0
public class ChooseDrinkState : State
{
    [Header("Required")]
    [SerializeField]
    private DrinkSelector drinkSelector = null;

    public override StateName StateName => StateName.ChooseDrink;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        stateData.Drink = null;

        GameManager.Instance.confirmButton.SetUserCanInput(true);
        drinkSelector.SetUserCanInput(true);
        WriteToTerminal("Bitte wähle ein Getränk aus.");
    }

    public override void Exit() {
        base.Exit();
        GameManager.Instance.confirmButton.SetUserCanInput(false);
        drinkSelector.SetUserCanInput(false);
    }

    /*
     * possibleNextStates:
     * 0 - q1 (EnoughResources)
     * 1 - q6 (InsufficientResources)
     * 2 - q7 (EmptyResources)
     */
    public override State CheckForTransition() {
        //if (false) // Substitue with a method to check if any drink can be still made from the left resources
        //    return possibleNextStates[2]; // q7

        if (confirmed)
            SelectDrink(drinkSelector.SelectedDrink);

        if (stateData.Drink == null)
            return null;
        
        if (stateData.HasSufficientResources())
            return possibleNextStates[0]; // q1

        return possibleNextStates[1]; // q6
    }

    public override void SelectDrink(DrinkData drink) {
        stateData.Drink = drink;
    }
}
