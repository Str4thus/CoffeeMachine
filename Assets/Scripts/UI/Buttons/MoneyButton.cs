using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyButton : MachineButton
{
    [SerializeField]
    private float value = 0f;

    public override void OnClickListener() {
        StateMachine.Instance.CurrentState.InsertMoney(value);
    }
}
