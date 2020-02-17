using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q3
public class PaymentComplete : State
{
    public override StateName StateName => StateName.PaymentComplete;

    /*
     * possibleNextStates:
     * 0 - q4 (MoneyReturn)
     * 1 - q5 (DrinkReady)
     */
    public override State CheckForTransition() {
        return null;
    }
}
