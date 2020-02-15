﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q1
public class EnoughResourcesState : State
{
    public override StateName StateName { get { return StateName.EnoughResources; } }

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrinkState)
     * 1 - q2 (PaymentStarted)
     */
    private bool aborted = false;

    public override State CheckForTransition() {
        if (aborted)
            return possibleNextStates[0];

        if (stateData.paidMoney > 0)
            return possibleNextStates[1];

        return null;
    }

    public override void UpdateSignalLights() {
        Debug.Log("BLUE BULB GLOWS!");
    }

    public override void InsertMoney(float value) {
        Debug.Log("Paid " + value + "€");
    }

    public override void Abort() {
        aborted = true;
    }
}
