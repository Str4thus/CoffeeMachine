using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q6
public class InsufficientResources : State
{
    public override StateName StateName => StateName.InsufficientResources;
    private bool aborted = false;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        aborted = false;
        GameManager.Instance.dangerBulb.TurnOn();
        GameManager.Instance.abortButton.SetUserCanInput(true);

        WriteToTerminal("Ungenügend Ressourcen für das Getränk.");
    }

    public override void Exit() {
        base.Exit();
        GameManager.Instance.dangerBulb.TurnOff();
        GameManager.Instance.abortButton.SetUserCanInput(false);
    }

    /*
     * possibleNextStates:
     * 0 - q1 (EnoughResources)
     */
    public override State CheckForTransition() {
        if (aborted)
            return possibleNextStates[0]; // q1
        return null;
    }

    public override void Abort() {
        aborted = true;
    }
}
