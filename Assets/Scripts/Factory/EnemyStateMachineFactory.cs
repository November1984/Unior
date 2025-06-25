using UnityEngine;

public class EnemyStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Enemy enemy, Path path)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine);
        State patrolState = new PatrolState(stateMachine, enemy, path);
        State targetReachedState = new TargetReachedState(stateMachine, path);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy, path);
        ToIdleStateTransition toIdleStateTransition = new (idleState, enemy);
        ToTargetReachedStateTransition toTargetReachedStateTransition = new(targetReachedState, enemy, path);

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