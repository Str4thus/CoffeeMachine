using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q4
public class MoneyReturn : State
{
    public override StateName StateName => StateName.MoneyReturn;

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrink)
     */
    public override State CheckForTransition() {
        return null;
    }
}
