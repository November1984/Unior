using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]

public class Unit : MonoBehaviour, IMovable
{
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _jumpSpeed = 6f;

    private Rigidbody2D _rigidBody;
    private bool _isOnGround;
    private GroundDetector _groundContactCounter;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public bool IsOnGround => _isOnGround;
    public Transform Transform => transform;

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

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}