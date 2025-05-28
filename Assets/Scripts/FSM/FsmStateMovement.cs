using System;
using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    
    protected readonly float _runSpeed;
    protected readonly float _jumpSpeed;

    protected readonly Unit _unit;
    protected readonly Transform _transform;
    protected readonly Rigidbody2D _rigidbody2D;
    protected readonly MovementAnimator _movementAnimator;

    public FsmStateMovement(
                Fsm fsm,
                Unit unit,
                float runSpeed,
                float jumpSpeed,
                MovementAnimator movementAnimator) : base(fsm)
    {
        _unit = unit;
        _transform = _unit.transform;
        _runSpeed = runSpeed;
        _jumpSpeed = jumpSpeed;
        _rigidbody2D = _unit.RigidBody;
        _movementAnimator = movementAnimator;
    }

    protected virtual void Move(float value)
    {
        Vector2 direction = new(value, 0);
        _transform.Translate(_runSpeed * Time.deltaTime * direction);

        if (_unit.IsOnGround)
            _movementAnimator.Move(GetDirection(value));
    }

    protected virtual void Jump()
    {
        if (_unit.IsOnGround)
        {
            _rigidbody2D.linearVelocityY = _jumpSpeed;
            _movementAnimator.Idle();
            _movementAnimator.Jump();
        }
        else
        {
            _movementAnimator.Landing();
        }
    }

    protected virtual void Land()
    {
        if (_unit.IsOnGround)
            _fsm.SetState<FsmStateIdle>();
        else
            _movementAnimator.Landing();
    }

    protected virtual void Idle()
    {
        _movementAnimator.Idle();
    }

    private int GetDirection(float value)
    {
        return (value == 0) ? 0 : Math.Sign(value);
    }
}