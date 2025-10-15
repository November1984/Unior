using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class Movement : MonoBehaviour
{
    [SerializeField] protected float _runSpeed = 1f;
    [SerializeField] protected float _jumpSpeed = 6f;

    private Rigidbody2D _rigidBody;
    private InputReader _inputReader;

    public event Action<int> Moved;

    public int MoveInput { get; private set; }
    public int JumpInput { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsVampiring { get; private set; }
    public float RunSpeed => _runSpeed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += MovedNotify;
        _inputReader.Jumped += JumpedNotify;
        _inputReader.IsAttacked += AttackedNotify;
        _inputReader.IsVampiring += VampireNotify;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= MovedNotify;
        _inputReader.Jumped -= JumpedNotify;
        _inputReader.IsAttacked -= AttackedNotify;
        _inputReader.IsVampiring -= VampireNotify;
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
        MoveInput = value;

        Moved?.Invoke(value);
    }

    public void JumpedNotify(int value)
    {
        JumpInput = value;
    }

    public void AttackedNotify(bool value)
    {
        IsAttacking = value;
    }

    public void VampireNotify(bool value)
    {
        IsVampiring = value;
    }
}