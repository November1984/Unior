using UnityEngine;

public class JumpState : FsmState
{
    private readonly float _jumpSpeed;
    private readonly Rigidbody2D _rigidbody;

    public JumpState(
                Fsm fsm,
                Rigidbody2D rigidbody,
                float jumpSpeed) : base(fsm)
    {
        _rigidbody = rigidbody;
        _jumpSpeed = jumpSpeed;
    }

    public override void Enter()
    {
        if (_fsm.IsOnGround)
            _characterAnimator.Jump();
    }

    public override void Update()
    {
        if (_fsm.IsOnGround && _fsm.JumpDirection > 0)
            _rigidbody.linearVelocityY = _jumpSpeed;

        if (_fsm.JumpDirection == 0 && _fsm.IsOnGround)
            _fsm.SetState<IdleState>();
        else
            _characterAnimator.Landing();

        if (_fsm.MoveDirection != 0)
            _fsm.SetState<MoveState>();
    }
}