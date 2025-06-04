using UnityEngine;

public class JumpState : FsmState
{
    private readonly float _jumpSpeed;
    private readonly Rigidbody2D _rigidbody;
    protected readonly CharacterAnimator _characterAnimator;

    public JumpState(
                FiniteStateMachine fsm,
                Rigidbody2D rigidbody,
                float jumpSpeed) : base(fsm)
    {
        _rigidbody = rigidbody;
        _jumpSpeed = jumpSpeed;
        _characterAnimator = _fsm.CharacterAnimator;
    }

    public override void Enter()
    {
        Debug.Log($"{this.GetType()} - Enter");


        _characterAnimator.Jump();
    }

    public override void Update()
    {
        if (_fsm.IsOnGround && _fsm.JumpDirection > 0)
        {
            _rigidbody.linearVelocityY = _jumpSpeed;
            return;
        }

        if (_fsm.IsOnGround)
        {
            _fsm.SetState<IdleState>();
            return;
        }

        if (_fsm.IsOnGround == false)
            _characterAnimator.Landing();

        if (_fsm.MoveDirection != 0)
            _fsm.SetState<MoveState>();
    }
}