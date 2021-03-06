﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q1
public class EnoughResourcesState : State
{
    public override StateName StateName => StateName.EnoughResources;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        GameManager.Instance.goodBulb.TurnOn();
        GameManager.Instance.abortButton.SetUserCanInput(true);
        GameManager.Instance.SetMoneyButtonEnabled(true);

        WriteToTerminal("Genügend Ressourcen vorhanden!" +
            "\n\n" +
            "Warte auf Zahlungsbeginn.");
    }

    public override void Exit() {
        base.Exit();
        GameManager.Instance.goodBulb.TurnOff();
        GameManager.Instance.abortButton.SetUserCanInput(false);
        GameManager.Instance.SetMoneyButtonEnabled(false);
    }

    /*
     * possibleNextStates:
     * 0 - q0 (ChooseDrinkState)
     * 1 - q2 (PaymentStarted)
     */
    public override State CheckForTransition() {
        if (aborted)
            return possibleNextStates[0]; // q0
        
        if (stateData.PaidMoney > 0f)
            return possibleNextStates[1]; // q2

        return null;
    }
}
