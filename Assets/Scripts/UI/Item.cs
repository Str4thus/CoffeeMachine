using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Item : MonoBehaviour
{
    protected Button button;

    private void Awake() {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickListener);
    }

    private void OnClickListener() {
        StateMachine.Instance.CurrentState.TakeItemFromEjectSlot();

        Destroy(gameObject);
    }
}
