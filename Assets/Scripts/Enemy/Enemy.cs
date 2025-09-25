using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
public class Enemy : MonoBehaviour, IDamageable, IAttacker, IChaser, IPatroller
{
    [SerializeField] Contactor _contactor;
    [SerializeField] Chaser _chaser;
    [SerializeField] Attacker _attacker;

    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private bool _canAttack;
    private bool _canChase;
    private bool _hasHealth;
    private Healthbars.Health _health;
    private Patroller _patroller;
    private bool _canPatrol;

    public Attacker Attacker => _canAttack ? _attacker : null;
    public IDamageable SpottedUnit { get; private set; }
    public bool IsUnitSpotted { get; private set; }
    public Vector3 SpottedUnitPosition => SpottedUnit.Position;
    public IDamageable AttackedUnit => ApproachedUnit;
    public Chaser Chaser => _canChase ? _chaser : null;
    public bool IsUnitApproached => _chaser.IsUnitApproached;
    public IDamageable ApproachedUnit => _chaser.ApproachedUnit;
    public bool IsUnitAttacked => _attacker.IsAttacking;
    public Patroller Patroller => _canPatrol ? _patroller : null;
    public bool CanPatrol => _canPatrol;
    public bool IsWaypointReached { get; private set; }
    Healthbars.Health IDamageable.Health => _hasHealth ? _health : null;
    Vector3 IDamageable.Position => SpottedUnit.Position;

    private void Awake()
    {
        _hasHealth = TryGetComponent<Healthbars.Health>(out _health);
        _canPatrol = TryGetComponent<Patroller>(out _patroller);
        _chaser.Unit = transform;
    }

    private void Start()
    {
        _canChase = _chaser != null;
        _canAttack = _attacker != null;
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void OnEnable()
    {
        _contactor.UnitSpotted += SetSpottedUnit;
        _patroller.Reached += WaypointReached;
    }

    private void OnDisable()
    {
        _contactor.UnitSpotted -= SetSpottedUnit;
        _patroller.Reached -= WaypointReached;
    }

    public void Initialize(WaypointsContainer path)
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = new EnemyStateMachineFactory().Create(this, path, _unitAnimator);
    }

    private void WaypointReached(bool value)
    {
        IsWaypointReached = value;
    }

    private void SetSpottedUnit(IDamageable unit)
    {
        if (_contactor.IsUnitSpoted)
        {
            IsUnitSpotted = true;
            SpottedUnit = unit;
        }
        else
        {
            IsUnitSpotted = false;
            SpottedUnit = null;
        }
    }
}