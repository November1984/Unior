using UnityEngine;

public class EnemyStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Enemy enemy, WaypointsContainer waypointsContainer, UnitAnimator unitAnimator)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine, unitAnimator);
        State patrolState = new PatrolState(stateMachine, enemy, waypointsContainer, unitAnimator);
        State targetReachedState = new TargetReachedState(stateMachine, waypointsContainer);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy, waypointsContainer);
        ToIdleStateTransition toIdleStateTransition = new (idleState, enemy);
        ToTargetReachedStateTransition toTargetReachedStateTransition = new(targetReachedState, enemy, waypointsContainer);

        initState.AddTransition(toIdleStateTransition);
        initState.AddTransition(toPatrolStateTransition);
        idleState.AddTransition(toPatrolStateTransition);
        idleState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toTargetReachedStateTransition);
        targetReachedState.AddTransition(toPatrolStateTransition);
        
        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}