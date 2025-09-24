using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(Contactor))]
public class Enemy : MonoBehaviour, IDamageable, IAttacker, IChaser, IPatroller
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Attacker _attacker;
    private bool _canAttack;
    private Chaser _chaser;
    private bool _canChase;
    private bool _hasHealth;
    private Healthbars.Health _health;
    private Contactor _contactor;
    private Patroller _patroller;
    private bool _canPatrol;

    public Attacker Attacker => _canAttack ? _attacker : null;
    public IDamageable SpottedUnit { get; private set; }
    public bool IsUnitSpotted { get; private set; }
    public Vector3 SpottedUnitPosition => SpottedUnit.Position;
    public IDamageable AttackedUnit => SpottedUnit;
    public Chaser Chaser => _canChase ? _chaser : null;
    public bool IsUnitApproached => _chaser.IsApproached;
    public bool IsUnitAttacked => _attacker.IsAttacking;
    public Patroller Patroller => _canPatrol ? _patroller : null;
    public bool CanPatrol => _canPatrol;
    public bool IsWaypointReached { get; private set; }
    Healthbars.Health IDamageable.Health => _hasHealth ? _health : null;
    Vector3 IDamageable.Position => SpottedUnit.Position;






    // IDamageable IAttacker.AttackedUnit => _canChase ? _chaser.SpottedUnit : null;
    // public Transform SpottedPlayer => _canChase ? _chaser.UnitPosition : null;
    // public bool IsPlayerSpotted => _canChase ? _chaser.IsPlayerSpotted : false;
    // public bool IsClosePosition => _canChase ? _chaser.IsClosePosition : false;
    // Contactor IChaser.Contactor => _chaser.Contactor;
    // Transform IChaser.UnitPosition => _chaser.UnitPosition;

    private void Awake()
    {
        _canAttack = TryGetComponent<Attacker>(out _attacker);
        _canChase = TryGetComponent<Chaser>(out _chaser);
        _hasHealth = TryGetComponent<Healthbars.Health>(out _health);
        _canPatrol = TryGetComponent(out _patroller);
        _contactor = GetComponent<Contactor>();
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