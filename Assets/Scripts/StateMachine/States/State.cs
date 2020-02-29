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
    protected bool confirmed = false;

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
        confirmed = false;

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

    public void AppendToTerminal(string message) {
        GameManager.Instance.terminal.AppendMessage(message);
    }



    public virtual void Abort() {
        aborted = true;
    }

    public virtual void Confirm() {
        confirmed = true;
    }
    
    /* StateActions */
    public virtual void SelectDrink(DrinkData drink) {
        Debug.Log("Not implemented.");
    }
    
    public virtual void InsertMoney(float value) {
        stateData.Pay(value);
    }
    
    public virtual void UpdateMoneyDisplay() {
        Debug.Log("Not implemented.");
    }
    
    public virtual void ReturnMoney() {
        Debug.Log("Not implemented.");
    }
    
    public virtual void ServeDrink() {
        Debug.Log("Not implemented.");
    }
    
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