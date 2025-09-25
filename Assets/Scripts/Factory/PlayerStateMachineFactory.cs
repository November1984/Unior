public class PlayerStateMachineFactory
{
    public StateMachine Create(Player player, UnitAnimator unitAnimator)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine, unitAnimator);
        State moveState = new MoveState(stateMachine, player, unitAnimator);
        State jumpState = new JumpState(stateMachine, player, unitAnimator);
        State attackState = new AttackState(stateMachine, player, unitAnimator);

        ToIdleStateTransition toIdleStateTransition = new(idleState, player);
        ToMoveStateTransition toMoveStateTransition = new(moveState, player);
        ToJumpStateTransition toJumpStateTransition = new(jumpState, player);
        ToPlayerAttackStateTransition toPlayerAttackStateTransition = new(attackState, player);

        initState.AddTransition(toIdleStateTransition);
        idleState.AddTransition(toMoveStateTransition);
        idleState.AddTransition(toJumpStateTransition);
        idleState.AddTransition(toPlayerAttackStateTransition);
        moveState.AddTransition(toIdleStateTransition);
        moveState.AddTransition(toJumpStateTransition);
        moveState.AddTransition(toPlayerAttackStateTransition);
        jumpState.AddTransition(toIdleStateTransition);
        jumpState.AddTransition(toMoveStateTransition);
        jumpState.AddTransition(toPlayerAttackStateTransition);
        attackState.AddTransition(toIdleStateTransition);
        attackState.AddTransition(toMoveStateTransition);
        attackState.AddTransition(toJumpStateTransition);

        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}