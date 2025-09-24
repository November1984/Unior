public class EnemyStateMachineFactory
{
    public StateMachine Create(Enemy enemy, WaypointsContainer waypointsContainer, UnitAnimator unitAnimator)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State patrolState = new PatrolState(stateMachine, enemy, waypointsContainer, unitAnimator);
        State targetReachedState = new TargetReachedState(stateMachine, waypointsContainer);
        State chaseState = new ChaseState(stateMachine, enemy, unitAnimator);
        State attackState = new AttackState(stateMachine, enemy, unitAnimator);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy);
        ToTargetReachedStateTransition toTargetReachedStateTransition = new(targetReachedState, enemy);
        ToChaseStateTransition toChaseStateTransition = new(chaseState, enemy);
        ToAttackStateTransition toAttackStateTransition = new(attackState, enemy);

        initState.AddTransition(toPatrolStateTransition);
        initState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toChaseStateTransition);
        patrolState.AddTransition(toAttackStateTransition);
        targetReachedState.AddTransition(toPatrolStateTransition);
        targetReachedState.AddTransition(toChaseStateTransition);
        targetReachedState.AddTransition(toAttackStateTransition);
        chaseState.AddTransition(toAttackStateTransition);
        chaseState.AddTransition(toPatrolStateTransition);
        attackState.AddTransition(toPatrolStateTransition);
        attackState.AddTransition(toTargetReachedStateTransition);
        attackState.AddTransition(toChaseStateTransition);
        
        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}