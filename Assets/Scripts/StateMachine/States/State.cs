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
    protected bool aborted = false;

    protected StateData stateData;
    public abstract StateName StateName { get; }

    [Header("UI")]
    [SerializeField]
    protected RawImage machineCell;

    public virtual void Enter(StateData stateData) {
        this.stateData = stateData;
        isActive = true;

        if (machineCell)
            machineCell.color = Color.red;
    }

    public virtual void Exit() {
        isActive = false;
        aborted = false;

        if (machineCell)
            machineCell.color = Color.black;
    }

    public virtual State CheckForTransition() {
        Debug.Log("No transitions available from this State! (Assure, that this is a final state)");
        return null;
    }

    public void WriteToTerminal(string message) {
        GameManager.Instance.terminal.WriteMessage(message);
    }


    public virtual void Abort() {
        aborted = true;
    }

    public virtual void Confirm() {
        Debug.Log("Not implemented.");
    }

    /* StateActions */
    // 0
    public virtual void SelectDrink(DrinkData drink) {
        Debug.Log("Not implemented.");
    }

    // 1, 2
    public virtual void InsertMoney(float value) {
        stateData.Pay(value);
    }

    // 2, 3
    public virtual void UpdateMoneyDisplay() {
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