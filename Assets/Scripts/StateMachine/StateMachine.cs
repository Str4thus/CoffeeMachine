using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private State startState;
    [SerializeField]
    private StateData stateData;

    private State currentState;

    private void Awake() {
        Resources.UnloadAsset(stateData); // Reset data of SO

        MakeTransition(startState);
    }

    private void Update() {
        TryTransition();
    }

    private void TryTransition() {
        State newState = currentState.CheckForTransition();
        if (newState) {
            MakeTransition(newState);
        }
    }


    private void MakeTransition(State newState) {
        if (currentState)
            currentState.Exit();

        newState.Enter(stateData);
        currentState = newState;
    }
}
