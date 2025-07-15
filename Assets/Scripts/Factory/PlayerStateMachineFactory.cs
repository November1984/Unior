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
        State talkState = new TalkState(stateMachine, player, unitAnimator);

        ToIdleStateTransition toIdleStateTransition = new(idleState, player);
        ToMoveStateTransition toMoveStateTransition = new(moveState, player);
        ToJumpStateTransition toJumpStateTransition = new(jumpState, player);
        ToPlayerTalkStateTransition toPlayerAttackStateTransition = new(talkState, player);

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
        talkState.AddTransition(toIdleStateTransition);
        talkState.AddTransition(toJumpStateTransition);
        talkState.AddTransition(toMoveStateTransition);

        stateMachine.ChangeState(initState);
        
        return stateMachine;
    }
}