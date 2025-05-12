using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    MovementAnimator _movementAnimator;

    private IMoveAble _unit;

    private void Start()
    {
        _movementAnimator = GetComponent<MovementAnimator>();
        _unit = GetComponent<IMoveAble>();

        _movementAnimator.Idle();
    }

    public void Jump(float value)
    {
        if (_unit.IsOnGround)
        { _movementAnimator.Idle(); }
        else
        {
            if (value <= 0)
                _movementAnimator.Landing();
        }

        if (value > 0 && _unit.IsOnGround)
        {
            _unit.Rigidbody.linearVelocityY = _unit.JumpSpeed;

            _movementAnimator.Jump();
        }
    }

    public void Move(Vector2 finishPosition)
    {
        _unit.Transform.position = Vector2.MoveTowards(transform.position,
                                    finishPosition,
                                    _unit.RunSpeed * Time.deltaTime
                                    );

        _movementAnimator.Move(GetDirectionCode(finishPosition.x - _unit.Transform.position.x));
    }

    public void Move(float value)
    {
        Vector2 direction = new(value, 0);
        _unit.Transform.Translate(_unit.RunSpeed * Time.deltaTime * direction);

        _movementAnimator.Move(GetDirectionCode(value));
    }

    private int GetDirectionCode(float value) => (value == 0) ? 0 : (int)(value / Math.Abs(value));
}
