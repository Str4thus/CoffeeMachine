using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConfirmButton : MonoBehaviour
{
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler() {
        StateMachine.Instance.CurrentState.Confirm();
    }
}
