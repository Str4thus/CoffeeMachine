using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q2
public class PaymentStarted : State
{
    public override StateName StateName => StateName.PaymentStarted;

    /*
     * possibleNextStates:
     * 0 - q3 (PaymentComplete)
     * 1 - q4 (MoneyReturn)
     */
    public override State CheckForTransition() {
        return null;
    }
}
