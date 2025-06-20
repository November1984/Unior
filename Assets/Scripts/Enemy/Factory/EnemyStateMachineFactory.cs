using UnityEngine;

public class EnemyStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Enemy enemy, Path path)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine);
        State patrolState = new PatrolState(stateMachine, enemy, path);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy, path);
        ToIdleStateTransition toIdleStateTransition = new (idleState, enemy);

        initState.AddTransition(toIdleStateTransition);
        initState.AddTransition(toPatrolStateTransition);
        idleState.AddTransition(toPatrolStateTransition);

        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}