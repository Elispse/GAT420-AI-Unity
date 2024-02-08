using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIIdleState : AIState
{
    public AIIdleState(AIStateAgent agent) : base(agent)
    {
        // to patrol
        AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
        transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
        transitions.Add(transition);

        // to chase
        transition = new AIStateTransition(nameof(AIChaseState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.timer.value = Random.Range(1, 3);
    }

    public override void OnExit()
    {
        Debug.Log("idle exit");
    }

    public override void OnUpdate()
    {

    }
}
