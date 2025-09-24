using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Contactor))]
public class Player : MonoBehaviour, IDamageable, IAttacker
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Movement _movement;
    private GroundDetector _groundContactCounter;
    private bool _isOnGround;
    private Healthbars.Health _health;
    private bool _hasHealth;
    private bool _canAttack;
    private Attacker _attacker;
    private Contactor _contactor;

    public Movement Movement => _movement;
    public bool IsOnGround => _isOnGround;
    public Attacker Attacker => _canAttack ? _attacker : null;
    Healthbars.Health IDamageable.Health => _hasHealth ? _health : null;
    Vector3 IDamageable.Position => transform.position;
    public bool IsUnitApproached { get; private set; }



    public IDamageable SpottedUnit { get; private set; }
    public IDamageable AttackedUnit { get; private set; }




    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _groundContactCounter = GetComponent<GroundDetector>();
        _hasHealth = TryGetComponent<Healthbars.Health>(out _health);
        _canAttack = TryGetComponent(out _attacker);
        _contactor = GetComponent<Contactor>();
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
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = new PlayerStateMachineFactory().Create(this, _unitAnimator);
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}