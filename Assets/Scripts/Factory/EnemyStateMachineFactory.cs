public class EnemyStateMachineFactory
{
    public StateMachine Create(Enemy enemy, WaypointsContainer waypointsContainer, UnitAnimator unitAnimator)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State patrolState = new PatrolState(stateMachine, enemy, waypointsContainer, unitAnimator);
        State targetReachedState = new TargetReachedState(stateMachine, waypointsContainer);
        State chaseState = new ChaseState(stateMachine, enemy, unitAnimator);
        State talkState = new AttackState(stateMachine, enemy, unitAnimator);

        ToPatrolStateTransition toPatrolStateTransition = new (patrolState, enemy, waypointsContainer);
        ToTargetReachedStateTransition toTargetReachedStateTransition = new(targetReachedState, enemy, waypointsContainer);
        ToChaseStateTransition toChaseStateTransition = new(chaseState, enemy);
        ToAttackStateTransition toTalkStateTransition = new(talkState, enemy);

        initState.AddTransition(toPatrolStateTransition);
        initState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toTargetReachedStateTransition);
        patrolState.AddTransition(toChaseStateTransition);
        patrolState.AddTransition(toTalkStateTransition);
        targetReachedState.AddTransition(toPatrolStateTransition);
        targetReachedState.AddTransition(toChaseStateTransition);
        targetReachedState.AddTransition(toTalkStateTransition);
        chaseState.AddTransition(toTalkStateTransition);
        chaseState.AddTransition(toPatrolStateTransition);
        talkState.AddTransition(toPatrolStateTransition);
        talkState.AddTransition(toTargetReachedStateTransition);
        talkState.AddTransition(toChaseStateTransition);
        
        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}