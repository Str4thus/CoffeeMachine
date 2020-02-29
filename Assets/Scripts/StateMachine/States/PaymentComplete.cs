using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q3
public class PaymentComplete : State
{
    public override StateName StateName => StateName.PaymentComplete;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);

        GameManager.Instance.abortButton.SetUserCanInput(true);
        GameManager.Instance.confirmButton.SetUserCanInput(true);

        WriteToTerminal("Zahlung erfolgreich." +
            "\n\n" +
            "Warte auf Bestätigung.");
    }

    public override void Exit() {
        base.Exit();
        
        GameManager.Instance.abortButton.SetUserCanInput(false);
        GameManager.Instance.confirmButton.SetUserCanInput(false);
    }

    /*
     * possibleNextStates:
     * 0 - q4 (MoneyReturn)
     * 1 - q5 (DrinkReady)
     */
    public override State CheckForTransition() {
        if (aborted) {
            WriteToTerminal("Vorgang abgebrochen.");
            return possibleNextStates[0]; // q4
        }

        if (confirmed) {
            stateData.UseRequiredResources();
            return possibleNextStates[1]; // q5
        }

        return null;
    }
}
