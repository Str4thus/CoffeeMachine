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
    
    private void Awake() {
        if (instance != null && instance != this) {
            Debug.Log("Rip");
            Destroy(gameObject);
        } else {
            instance = this;

            Resources.UnloadAsset(stateData); // Reset data of SO
            MakeTransition(startState);
        }
    }

    private void Update() {
        TryTransition();
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
