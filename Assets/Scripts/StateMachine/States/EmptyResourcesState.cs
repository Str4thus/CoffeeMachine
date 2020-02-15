using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q7
public class EmptyResourcesState : State
{
    public override StateName StateName { get { return StateName.EmptyResources; } }

    public override void Enter(StateData stateData) {
        base.Enter(stateData);
        End();
    }

    private void Awake() {
        isFinal = true;
    }

    public override void End() {
        Debug.Log("Endstate reached!");
    }
}
