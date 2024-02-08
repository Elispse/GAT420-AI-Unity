using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFleeState : AIState
{
    float initialSpeed;
    public AIFleeState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new FloatCondition(agent.enemyDistance, Condition.Predicate.GREATER, 8));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        Debug.Log("Flee Entered");
        agent.movement.Resume();
        initialSpeed = agent.movement.maxSpeed;
        agent.movement.maxSpeed *= 2;
    }

    public override void OnUpdate()
    {
        if (agent.enemy.enemySeen)
        {
            agent.movement.destination = agent.enemy.transform.position * -1;
            Debug.Log("Flee Update");
        }
    }

    public override void OnExit()
    {

    }
}