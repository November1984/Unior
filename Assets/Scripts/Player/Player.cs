using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable, IAttacker, IVampire
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Vampire _vampire;
    [SerializeField] private Movement _movement;
    
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private GroundDetector _groundContactCounter;
    private Rigidbody2D _rigidbody2D;
    private bool _isOnGround;
    private Healthbars.Health _health;
    private bool _hasHealth;
    private bool _canMove;
    private bool _canAttack;
    private bool _canVampire;

    public Transform Transform => transform;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Movement Movement => _canMove ? _movement : null;
    public bool IsOnGround => _isOnGround;
    public Attacker Attacker => _canAttack ? _attacker : null;
    public bool IsUnitAutoAttacking => false;
    public IDamageable SpottedUnit { get; private set; }
    public Vampire Vampire => _canVampire ? _vampire : null;
    Healthbars.Health IDamageable.Health => _hasHealth ? _health : null;
    Vector3 IDamageable.Position => transform.position;

    private void Awake()
    {
        _groundContactCounter = GetComponent<GroundDetector>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _hasHealth = TryGetComponent<Healthbars.Health>(out _health);
    }

    private void Start()
    {
        _canAttack = _attacker != null;
        _canVampire = _vampire != null;
        _canMove = _movement != null;
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