using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q2
public class PaymentStarted : State
{
    public override StateName StateName => StateName.PaymentStarted;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        
        GameManager.Instance.abortButton.SetUserCanInput(true);
        GameManager.Instance.SetMoneyButtonEnabled(true);

        WriteToTerminal("Zahlung begonnen." +
            "\n\n" + 
            "Warte auf Begleich des Betrages.");
    }

    public override void Exit() {
        base.Exit();
        
        GameManager.Instance.abortButton.SetUserCanInput(false);
        GameManager.Instance.SetMoneyButtonEnabled(false);
    }

    /*
     * possibleNextStates:
     * 0 - q3 (PaymentComplete)
     * 1 - q4 (MoneyReturn)
     */
    public override State CheckForTransition() {
        if (aborted)
            return possibleNextStates[1]; // q4

        if (stateData.HasPaidEnough() && !stateData.IsAmountChangable()) {
            WriteToTerminal("Betrag kann nicht gewechselt werden.");
            return possibleNextStates[1]; // q4
        }
            
        if (stateData.HasPaidEnough() && stateData.IsAmountChangable())
            return possibleNextStates[0]; // q3
        
        return null;
    }
}
