using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q4
public class MoneyReturn : State
{
    public override StateName StateName => StateName.MoneyReturn;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);

        AppendToTerminal("Bitte Geld entnehmen.");
    }

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrink)
     */
    public override State CheckForTransition() {
        // Implement button that represents money, and when click it invokes stateData.ReturnOddMoney()
        return null;
    }
}
