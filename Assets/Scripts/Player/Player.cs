using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour, IMoveAble
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private Wallet _wallet;

    public event Action<bool> IsGrounded;

    private Rigidbody2D _rigidBody;
    
    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public Transform Transform => transform;

    private void OnEnable() => _rigidBody = GetComponent<Rigidbody2D>();
    public void OnCollisionStay2D(Collision2D collision) => IsGrounded?.Invoke(true);
    public void OnCollisionExit2D(Collision2D collision) => IsGrounded?.Invoke(false);
    public void CollectCoin() => _wallet?.AddCoin();
}
