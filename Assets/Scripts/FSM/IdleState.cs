using UnityEngine;

public class IdleState : FsmState
{
    protected readonly CharacterAnimator _characterAnimator;
    
    public IdleState(FiniteStateMachine fsm) : base(fsm)
    {
        _characterAnimator = _fsm.CharacterAnimator;
    }

    public override void Enter()
    {
        Debug.Log($"{this.GetType()} - Enter");
        _characterAnimator.Idle();
    }

    public override void Update()
    {
        if (_fsm.MoveDirection != 0)
            _fsm.SetState<MoveState>();

        if (_fsm.JumpDirection != 0)
            _fsm.SetState<JumpState>();
    }
}