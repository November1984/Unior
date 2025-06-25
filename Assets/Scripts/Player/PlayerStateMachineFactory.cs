using UnityEngine;

public class PlayerStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Player player)
    {
        StateMachine stateMachine = new();

        State initState = new InitState(stateMachine);
        State idleState = new IdleState(stateMachine);
        State moveState = new MoveState(stateMachine, player);
        State jumpState = new JumpState(stateMachine, player);

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