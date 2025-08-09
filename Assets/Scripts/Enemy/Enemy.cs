using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]

public class Enemy : Unit
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Player _spottedPlayer;
    private Contactor _contactor;
    private bool _isPlayerSpotted = false;

    public Player SpottedPlayer => _spottedPlayer;
    public Contactor Contactor => _contactor;
    public bool IsPlayerSpotted => _isPlayerSpotted; 

    private void OnDisable()
    {
        if (_contactor != null)
            _contactor.PlayerSpotted -= PlayerSpottedNotify;
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(WaypointsContainer path)
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, path, _unitAnimator);

        if (TryGetComponent<Contactor>(out _contactor))
            _contactor.PlayerSpotted += PlayerSpottedNotify;
    }

    public void MoveTo(Vector3 waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, Movement.RunSpeed * Time.deltaTime);
        _unitAnimator.MoveDirection = Math.Sign(waypoint.x - transform.position.x);
    }

    private void PlayerSpottedNotify(Player player)
    {
        _isPlayerSpotted = _contactor.IsPlayerSpoted;
        _spottedPlayer = player;
    }
}
