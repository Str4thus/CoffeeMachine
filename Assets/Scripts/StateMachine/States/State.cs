using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class State : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    protected bool isActive = false;
    [SerializeField]
    protected bool isFinal = false;
    [SerializeField]
    protected List<State> possibleNextStates = new List<State>();

    protected StateData stateData;
    public abstract StateName StateName { get; }

    [Header("UI")]
    [SerializeField]
    protected RawImage machineCell;

    public virtual void Enter(StateData stateData) {
        Debug.Log("Active State: " + this.name);
        this.stateData = stateData;
        isActive = true;

        if (machineCell)
            machineCell.color = Color.red;
    }

    public virtual void Exit() {
        isActive = false;

        if (machineCell)
            machineCell.color = Color.black;
    }

    public abstract State CheckForTransition();

    /* StateActions */
    // 0
    public virtual void SelectDrink(DrinkData drink) {
        Debug.Log("Not implemented.");
    }

    // 1
    public virtual void UpdateSignalLights() {
        Debug.Log("Not implemented.");
    }

    // 1, 2
    public virtual void InsertMoney(float value) {
        Debug.Log("Not implemented.");
    }

    // 2, 3
    public virtual void UpdateMoneyDisplay() {
        Debug.Log("Not implemented.");
    }

    // 2, 3
    public virtual void Abort() {
        Debug.Log("Not implemented.");
    }

    // 3
    public virtual void Confirm() {
        Debug.Log("Not implemented.");
    }

    // 4
    public virtual void ReturnMoney() {
        Debug.Log("Not implemented.");
    }

    // 5
    public virtual void ServeDrink() {
        Debug.Log("Not implemented.");
    }

    // 6
    public virtual void End() {
        Debug.Log("Not implemented.");
    }
}


public enum StateName {
    ChooseDrink,
    EnoughResources,
    PaymentStarted,
    PaymentCompleted,
    MoneyReturn,
    DrinkReady,
    InsufficientResources
}