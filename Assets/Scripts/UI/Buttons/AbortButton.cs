using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbortButton : MachineButton
{
    public override void OnClickListener() {
        StateMachine.Instance.CurrentState.Abort();
    }
}
