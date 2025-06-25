using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]

public class Unit : MonoBehaviour
{
    [SerializeField] protected float _runSpeed = 1f;
    [SerializeField] protected float _jumpSpeed = 6f;

    public event Action<int> Moved;
    public event Action<int> Jumped;
    
    private Rigidbody2D _rigidBody;
    private bool _isOnGround;
    private GroundDetector _groundContactCounter;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundContactCounter = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
    }

    public void MoveNotify(int value)
    {
        Moved?.Invoke(value);
    }

    public void JumpedNotify(int value)
    {
        Jumped?.Invoke(value);
    }

    public void Move(int direction)
    {
        Vector2 position = (Vector2) transform.position + direction * RunSpeed * Time.deltaTime * Vector2.right;
        transform.position = position;
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}