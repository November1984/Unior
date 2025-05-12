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
        if (value > 0)
        {
            _unit.Rigidbody.linearVelocityY = _unit.JumpSpeed;

            _movementAnimator.Jump();
            return;
        }

        _movementAnimator.Idle();
    }

    public void SetMoveDirection(Vector2 finishPosition)
    {
        _unit.Transform.position = Vector2.MoveTowards(transform.position,
                                    finishPosition,
                                    _unit.RunSpeed * Time.deltaTime
                                    );

        float MoveDirection = finishPosition.x - _unit.Transform.position.x;
        int moveDirectionCode = (int)(MoveDirection / Math.Abs(MoveDirection));

        _movementAnimator.Move(moveDirectionCode);
    }
}
