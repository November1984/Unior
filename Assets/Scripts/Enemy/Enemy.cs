using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IMoveAble
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;

    private Rigidbody2D _rigidBody;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Transform Transform => transform;
    public bool IsOnGround => true;
    public Rigidbody2D Rigidbody => _rigidBody;

    private void OnEnable() => _rigidBody = GetComponent<Rigidbody2D>();
}
