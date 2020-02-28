using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q5
public class DrinkReady : State
{
    public override StateName StateName => StateName.DrinkReady;

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrink)
     * 1 - q4 (MoneyReturn) if the user paid more than required
     */
    public override State CheckForTransition() {
        return null;
    }
}
