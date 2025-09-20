using System;
using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1f;

    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Attacker _attacker;
    private bool _canAttack;
    private Chaser _chaser;
    private bool _canChase;

    public IDamageable AttackedUnit => GetVictim(SpottedPlayer);
    public Attacker Attacker => _canAttack ? _attacker : null;
    public bool IsPlayerSpotted => _canChase ? _chaser.IsPlayerSpotted : false;
    public bool IsClosePosition => _canChase ? _chaser.IsClosePosition : false;
    public Transform SpottedPlayer => _canChase ? _chaser.PlayerPosition : null;

    private void Awake()
    {
        _canAttack = TryGetComponent<Attacker>(out _attacker);
        _canChase = TryGetComponent<Chaser>(out _chaser);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(WaypointsContainer path)
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = new EnemyStateMachineFactory().Create(this, path, _unitAnimator);
    }

    public void MoveTo(Vector3 waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);
        _unitAnimator.MoveDirection = Math.Sign(waypoint.x - transform.position.x);
    }

    public IDamageable GetVictim(Transform value)
    {
        if (value.TryGetComponent<IDamageable>(out IDamageable component))
            return component;

        return null;
    }
}
