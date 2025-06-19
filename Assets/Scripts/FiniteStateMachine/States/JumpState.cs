using UnityEngine;

public class JumpState : State
{
    private readonly float _jumpSpeed;
    private readonly Rigidbody2D _rigidbody;
    private readonly CharacterAnimator _characterAnimator;
    private readonly Unit _unit;

    private int _jumpDirection;
    private int _moveDirection;
    private bool _isLanded = false;

    public JumpState(
                StateMachine fsm,
                Unit unit,
                CharacterAnimator characterAnimator
                ) : base(fsm)
    {
        _unit = unit;
        _characterAnimator = characterAnimator;
        _rigidbody = _unit.Rigidbody;
        _jumpSpeed = _unit.JumpSpeed;
    }

    public override void Enter()
    {
        _unit.Moved += SetMoveDirection;
        _unit.Jumped += SetJumpDirection;
    }

    public override void Update()
    {
        if (_unit.IsOnGround && _jumpDirection > 0)
        {
            _characterAnimator.Jump();
            _rigidbody.linearVelocityY = _jumpSpeed;
        }

        if (_unit.IsOnGround == false)
        {
            _characterAnimator.Landing();
            _isLanded = true;
        }

        if (_moveDirection != 0)
        {
            _fsm.SetState<MoveState>();
            _moveDirection = 0;
        }

        if (_unit.IsOnGround && _isLanded)
        {
            _characterAnimator.Idle();
            _isLanded = false;
        }
    }

    public override void Exit()
    {
        _unit.Moved -= SetMoveDirection;
        _unit.Jumped -= SetJumpDirection;
    }

    private void SetMoveDirection(int value)
    {
        if (value != 0)
            _moveDirection = value;
    }

    private void SetJumpDirection(int value)
    {
        _jumpDirection = value;
        Update();
    }
}