using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    [SerializeField]
    private State startState = null;
    [SerializeField]
    private StateData stateData = null;

    private static StateMachine instance = null;
    public static StateMachine Instance { get { return instance; } }

    public State CurrentState { get; private set; }
    
    private void Start() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            Resources.UnloadAsset(stateData); // Reset data of SO
        }
    }

    private void Update() {
        // GameManager disables all input fields before the state machine should start operating
        if (!CurrentState && GameManager.Instance.IsReady) {
            MakeTransition(startState);
        } else if (CurrentState) {
            TryTransition();
        }
    }

    private void TryTransition() {
        State newState = CurrentState.CheckForTransition();
        if (newState) {
            MakeTransition(newState);
        }
    }


    private void MakeTransition(State newState) {
        if (CurrentState)
            CurrentState.Exit();

        newState.Enter(stateData);
        CurrentState = newState;
    }
}
