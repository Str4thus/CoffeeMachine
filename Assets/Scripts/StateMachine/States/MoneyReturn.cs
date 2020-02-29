using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q4
public class MoneyReturn : State
{
    public override StateName StateName => StateName.MoneyReturn;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);

        GameManager.Instance.CreateOddMoneyGameObject();
        AppendToTerminal("Bitte Geld entnehmen.");
    }

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrink)
     */
    public override State CheckForTransition() {
        if (tookItem) {
            stateData.ReturnMoney();
            return possibleNextStates[0]; // q0
        }

        return null;
    }
}
