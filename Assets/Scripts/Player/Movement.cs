using System;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class Movement : MonoBehaviour, IMover
{
    public event Action<int> ObjectMoved;
    public event Action<bool> ObjectJumped;

    private Player _player;
    private Rigidbody2D _rigidBody;
    private readonly string _horisontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetMoveDirection(Input.GetAxisRaw(_horisontal));
        Jump(Input.GetAxisRaw(_vertical));
    }

    private void Jump(float value)
    {
        if (value > 0 && _player.IsGrounded)
        {
            _rigidBody.linearVelocityY = _player.JumpSpeed;

            JumpedNotify(true);
            return;
        }

        JumpedNotify(false);
    }

    private void SetMoveDirection(float value)
    {
        float moveDirection;

        if (value == 0)
        { moveDirection = value; }
        else
        {
            Vector2 direction = new(value, 0);
            transform.Translate(_player.RunSpeed * Time.deltaTime * direction);
            moveDirection = value / Math.Abs(value);
        }

        MovedNotify((int)moveDirection);
    }

    private void MovedNotify(int value) => ObjectMoved?.Invoke(value);
    private void JumpedNotify(bool value) => ObjectJumped?.Invoke(value);
}
