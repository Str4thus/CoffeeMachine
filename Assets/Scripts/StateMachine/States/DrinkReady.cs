using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkReady : State
{
    public override StateName StateName => StateName.DrinkReady;

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrink)
     */
    public override State CheckForTransition() {
        return null;
    }
}
