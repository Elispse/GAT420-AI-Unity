using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveState : AIState
{
    float timer;
    public AIWaveState(AIStateAgent agent) : base(agent)
    {
    }

    public override void OnEnter()
    {
        timer = Time.time + 2;
        agent.animator?.SetTrigger("Wave");
        Debug.Log("Wave");
    }

    public override void OnUpdate()
    {
        if (Time.time > timer)
        {
            agent.stateMachine.SetState(nameof(AIIdleState));
        }
    }

    public override void OnExit()
    {
    }
}
