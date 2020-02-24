using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q7
public class EmptyResourcesState : State
{
    public override StateName StateName => StateName.EmptyResources;

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        GameManager.Instance.goodBulb.TurnOn();
        GameManager.Instance.dangerBulb.TurnOn();

        WriteToTerminal("Maschine bitte auffüllen.");
        End();
    }

    private void Awake() {
        isFinal = true;
    }

    public override void End() {
        Debug.Log("Endstate reached!");
    }
}
