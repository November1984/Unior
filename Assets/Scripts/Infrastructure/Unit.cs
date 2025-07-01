using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]

public class Unit : MonoBehaviour
{
    [SerializeField] protected float _runSpeed = 1f;
    [SerializeField] protected float _jumpSpeed = 6f;

    private Rigidbody2D _rigidBody;
    private bool _isOnGround;
    private GroundDetector _groundContactCounter;
    private InputReader _inputReader;
    private int _moveInput;
    private int _jumpInput;

    public event Action<int> Jumped;
    public event Action<int> Moved;

    public int MoveInput => _moveInput;
    public int JumpInput => _jumpInput;
    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundContactCounter = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
        _inputReader.Moved += MovedNotify;
        _inputReader.Jumped += JumpedNotify;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
        _inputReader.Moved -= MovedNotify;
        _inputReader.Jumped -= JumpedNotify;
    }

     public void Move(int direction)
    {
        Vector2 position = (Vector2)transform.position + direction * RunSpeed * Time.deltaTime * Vector2.right;
        transform.position = position;
    }

    public void Jump()
    {
        _rigidBody.linearVelocityY = _jumpSpeed;
    }

    public void MovedNotify(int value)
    {
        _moveInput = value;

        Moved?.Invoke(value);
    }

    public void JumpedNotify(int value)
    {
        _jumpInput = value;

        Jumped?.Invoke(value);
    }

   private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}