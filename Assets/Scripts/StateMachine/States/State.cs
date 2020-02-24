using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class State : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    protected List<State> possibleNextStates = new List<State>();
    protected bool isActive = false;
    protected bool isFinal = false;

    protected StateData stateData;
    public abstract StateName StateName { get; }

    [Header("UI")]
    [SerializeField]
    protected RawImage machineCell;

    public virtual void Enter(StateData stateData) {

        Debug.Log("Entered " + transform.name);
        this.stateData = stateData;
        isActive = true;

        if (machineCell)
            machineCell.color = Color.red;
    }

    public virtual void Exit() {
        Debug.Log("Exited " + transform.name);
        isActive = false;

        if (machineCell)
            machineCell.color = Color.black;
    }

    public virtual State CheckForTransition() {
        Debug.Log("No transitions available from this State! (Assure, that this is a final state)");
        return null;
    }

    /* StateActions */
    // 0
    public virtual void SelectDrink(DrinkData drink) {
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
    PaymentComplete,
    MoneyReturn,
    DrinkReady,
    InsufficientResources,
    EmptyResources
}