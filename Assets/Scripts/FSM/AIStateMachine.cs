using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    public AIState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState?.OnUpdate();
    }
    public void AddState(string name, AIState state)
    {
        states[name] = state;
    }

    public void SetState(string name)
    {
        var nextState = states[name];

        if (CurrentState == nextState) return;

        //exit current state
        CurrentState?.OnExit();
        // set next state
        CurrentState = nextState;
        // enter new state
        CurrentState?.OnEnter();
    }
}