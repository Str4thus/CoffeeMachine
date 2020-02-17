using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class MachineButton : MonoBehaviour
{
    protected Button button;

    private void Awake() {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickListener);
    }

    public virtual void OnClickListener() {
        Debug.Log("Click not implemented!");
    }

    public void SetUserCanInput(bool isActive) {
        button.interactable = isActive;
    }
}
