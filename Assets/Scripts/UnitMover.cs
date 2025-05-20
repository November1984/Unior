using UnityEngine;
using System;

[RequireComponent(typeof(CharacterAnimator))]

public class UnitMover : MonoBehaviour
{
    private Unit _unit;
    private CharacterAnimator _movementAnimator;

    private void Awake()
    {
        _movementAnimator = GetComponent<CharacterAnimator>();
        _unit = GetComponent<Unit>();
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

    public void Move(float value)
    {
        Vector2 direction = new(value, 0);
        _unit.Transform.Translate(_unit.RunSpeed * Time.deltaTime * direction);

        _movementAnimator.Move(GetDirection(value));
    }

    public void Idle()
    { _movementAnimator.Idle(); }

    private int GetDirection(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}