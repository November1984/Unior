using System;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerState _palyerState;
    [SerializeField] private Player _palyer;

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
        if (_palyerState.IsOnGround)
        { _movementAnimator.Idle(); }
        else
        {
            if (value <= 0)
                _movementAnimator.Landing();
        }

        if (value > 0 && _palyerState.IsOnGround)
        {
            _palyer.Rigidbody.linearVelocityY = _palyer.JumpSpeed;

            _movementAnimator.Jump();
        }
    }

    public void Move(float value)
    {
        Vector2 direction = new(value, 0);
        _palyer.Transform.Translate(_palyer.RunSpeed * Time.deltaTime * direction);

        _movementAnimator.Move(GetDirectionCode(value));
    }

    private int GetDirectionCode(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}
