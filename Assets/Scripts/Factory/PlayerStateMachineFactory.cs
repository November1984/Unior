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
        State vampireState = new VampireState(stateMachine, player);

        ToIdleStateTransition toIdleStateTransition = new(idleState, player);
        ToMoveStateTransition toMoveStateTransition = new(moveState, player);
        ToJumpStateTransition toJumpStateTransition = new(jumpState, player);
        ToPlayerAttackStateTransition toPlayerAttackStateTransition = new(attackState, player);
        ToVampireStateTransition toVampireStateTransition = new(vampireState, player);

        initState.AddTransition(toIdleStateTransition);
        idleState.AddTransition(toMoveStateTransition);
        idleState.AddTransition(toJumpStateTransition);
        idleState.AddTransition(toPlayerAttackStateTransition);
        idleState.AddTransition(toVampireStateTransition);
        moveState.AddTransition(toIdleStateTransition);
        moveState.AddTransition(toJumpStateTransition);
        moveState.AddTransition(toPlayerAttackStateTransition);
        moveState.AddTransition(toVampireStateTransition);
        jumpState.AddTransition(toIdleStateTransition);
        jumpState.AddTransition(toMoveStateTransition);
        jumpState.AddTransition(toPlayerAttackStateTransition);
        jumpState.AddTransition(toVampireStateTransition);
        attackState.AddTransition(toIdleStateTransition);
        attackState.AddTransition(toMoveStateTransition);
        attackState.AddTransition(toJumpStateTransition);
        attackState.AddTransition(toVampireStateTransition);
        vampireState.AddTransition(toIdleStateTransition);
        vampireState.AddTransition(toJumpStateTransition);
        vampireState.AddTransition(toMoveStateTransition);
        vampireState.AddTransition(toPlayerAttackStateTransition);

        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}