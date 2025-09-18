using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1f;
    
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Player _spottedPlayer;
    private bool _isPlayerSpotted = false;
    private Contactor _contactor;
    private Talker _talker;
    private bool _canTalk;

    public Player SpottedPlayer => _spottedPlayer;
    public Contactor Contactor => _contactor;
    public bool IsPlayerSpotted => _isPlayerSpotted;
    public float TalkDistance => _canTalk ? _talker.TalkDistance : -1;
    public bool IsTalking => _talker.IsTalking;

    private void Awake()
    {
        _canTalk = TryGetComponent<Talker>(out _talker);
    }

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
        transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);
        _unitAnimator.MoveDirection = Math.Sign(waypoint.x - transform.position.x);
    }

    public void Talk(bool value)
    {
        _talker.Talk(value);
    }

    private void PlayerSpottedNotify(Player player)
    {
        _isPlayerSpotted = _contactor.IsPlayerSpoted;
        _spottedPlayer = player;
    }
}
