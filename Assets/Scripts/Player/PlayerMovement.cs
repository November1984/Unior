using System;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _unit;

    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    private ActionAnimator _movementAnimator;

    private void Awake()
    {
        _movementAnimator = GetComponent<ActionAnimator>();
    }

    private void Update()
    {
        Move(Input.GetAxisRaw(Horisontal));
        Jump(Input.GetAxisRaw(Vertical));
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

        _movementAnimator.Move(GetDirectionCode(value));
    }

    private int GetDirectionCode(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}
