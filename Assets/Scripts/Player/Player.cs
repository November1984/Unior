using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(GroundDetector))]
public class Player : MonoBehaviour, IDamageable
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Movement _movement;
    private GroundDetector _groundContactCounter;
    private bool _isOnGround;
    private Healthbars.Health _health;
    private bool _hasHealth;

    public Movement Movement => _movement;
    public bool IsOnGround => _isOnGround;
    Healthbars.Health IDamageable.Health { get => _hasHealth ? _health : null; }

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _groundContactCounter = GetComponent<GroundDetector>();
        _hasHealth = TryGetComponent<Healthbars.Health>(out _health);
        _unitAnimator = GetComponent<UnitAnimator>();
        
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
        _stateMachine?.Update();
    }

    public void Initialize()
    {
        _stateMachine = new PlayerStateMachineFactory().Create(this, _unitAnimator);
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}