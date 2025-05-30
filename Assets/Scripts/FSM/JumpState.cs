using UnityEngine;

public class JumpState : FsmState
{
    private readonly float _jumpSpeed;
    private Rigidbody2D _rigidbody;

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
        _characterAnimator.Jump();
    }

    public override void Update()
    {
        if (_fsm.IsOnGround)
            _rigidbody.linearVelocityY = _jumpSpeed;

        if (_fsm.JumpDirection == 0 && _fsm.IsOnGround)
            _characterAnimator.Idle();
        else
            _characterAnimator.Landing();
    }
}