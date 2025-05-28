using UnityEngine;

public class Unit
{
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _jumpSpeed = 6f;

    private Rigidbody2D _rigidBody;
    private bool _isOnGround;
    private GroundDetector _groundContactCounter;
    private Fsm _fsm;
    private MovementAnimator _movementAnimator;

    public Rigidbody2D RigidBody => _rigidBody;
    public bool IsOnGround => _isOnGround;

    public Unit(Rigidbody2D rigidbody2D,
                GroundDetector groundDetector,
                MovementAnimator movementAnimator)
    {
        _rigidBody = rigidbody2D;
        _groundContactCounter = groundDetector;
        _movementAnimator = movementAnimator;
    }

    private void Awake()
    {
        _fsm = new Fsm();

        _fsm.AddState(new FsmStateIdle(_fsm, this, _runSpeed, _jumpSpeed, _movementAnimator));
        _fsm.AddState(new FsmStateRun(_fsm, this, _runSpeed, _jumpSpeed, _movementAnimator));
        _fsm.AddState(new FsmStateJump(_fsm, this, _runSpeed, _jumpSpeed, _movementAnimator));

        _fsm.SetState<FsmStateIdle>();
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
    }

    private void Update()
    {
        _fsm.Update();
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}