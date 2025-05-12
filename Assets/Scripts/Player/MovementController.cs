using System;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class MovementController : MonoBehaviour
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
        // SetMoveDirection(Input.GetAxisRaw(_horisontal));
        // Jump(Input.GetAxisRaw(_vertical));
    }

}
