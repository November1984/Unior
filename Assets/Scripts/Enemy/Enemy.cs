using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IMoveAble
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;

    private Rigidbody2D _rigidBody;
    private GroundContactCounter _groundContactCounter;
    private bool _isOnGround;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Transform Transform => transform;
    public bool IsOnGround => _isOnGround;
    public Rigidbody2D Rigidbody => _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundContactCounter = GetComponent<GroundContactCounter>();
    }

    private void OnEnable()
    { _groundContactCounter.IsOnGround += Grounded; }

    private void OnDisable()
    { _groundContactCounter.IsOnGround -= Grounded; }

    private void Grounded(bool value)
    { _isOnGround = value; }
}
