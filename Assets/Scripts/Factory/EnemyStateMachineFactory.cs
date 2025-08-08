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
        State chaseState = new ChaseState(stateMachine, enemy, unitAnimator);
        State enemyTalkState = new EnemyTalkState(stateMachine, enemy, unitAnimator);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy, waypointsContainer);
        ToIdleStateTransition toIdleStateTransition = new (idleState, enemy);
        ToTargetReachedStateTransition toTargetReachedStateTransition = new(targetReachedState, enemy, waypointsContainer);
        ToChaseStateTransition toChaseStateTransition = new(chaseState, enemy);
        ToEnemyTalkStateTransition toAttackStateTransition = new(enemyTalkState, enemy);

        initState.AddTransition(toIdleStateTransition);
        initState.AddTransition(toPatrolStateTransition);
        idleState.AddTransition(toPatrolStateTransition);
        idleState.AddTransition(toTargetReachedStateTransition);
        idleState.AddTransition(toAttackStateTransition);
        patrolState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toChaseStateTransition);
        patrolState.AddTransition(toAttackStateTransition);
        targetReachedState.AddTransition(toPatrolStateTransition);
        targetReachedState.AddTransition(toChaseStateTransition);
        targetReachedState.AddTransition(toAttackStateTransition);
        chaseState.AddTransition(toAttackStateTransition);
        
        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}