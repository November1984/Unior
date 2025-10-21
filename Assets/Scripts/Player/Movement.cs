using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float _runSpeed = 1f;
    [SerializeField] protected float _jumpSpeed = 6f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Player _player;

    public event Action<int> Moved;

    public int MoveInput { get; private set; }
    public int JumpInput { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsVampiring { get; private set; }
    public float RunSpeed => _runSpeed;

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
        Vector3 position = transform.position + direction * RunSpeed * Time.deltaTime * Vector3.right;
        _player.Transform.position = position;
    }

    public void Jump()
    {
        _player.Rigidbody2D.linearVelocityY = _jumpSpeed;
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