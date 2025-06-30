using UnityEngine;

public class PlayerStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Player player, UnitAnimator unitAnimator)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine, unitAnimator);
        State moveState = new MoveState(stateMachine, player, unitAnimator);
        State jumpState = new JumpState(stateMachine, player, unitAnimator);

        ToIdleStateTransition toIdleStateTransition = new(idleState, player);
        ToMoveStateTransition toMoveStateTransition = new(moveState);
        ToJumpStateTransition toJumpStateTransition = new(jumpState, player);

        initState.AddTransition(toIdleStateTransition);
        idleState.AddTransition(toMoveStateTransition);
        idleState.AddTransition(toJumpStateTransition);
        moveState.AddTransition(toIdleStateTransition);
        moveState.AddTransition(toJumpStateTransition);
        jumpState.AddTransition(toIdleStateTransition);
        jumpState.AddTransition(toMoveStateTransition);

        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}