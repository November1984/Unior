public class IdleState : FsmState
{
    public IdleState(Fsm fsm) : base(fsm) { }

    public override void Enter()
    {
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