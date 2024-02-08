using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveState : AIState
{
    float timer;
    public AIWaveState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        Debug.Log("Wave Enter");
        agent.movement.Stop();
        agent.movement.velocity = Vector3.zero;
        agent.animator?.SetTrigger("Wave");
        agent.timer.value = 2;
        agent.hasWaved.value = true;
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
    }
}
