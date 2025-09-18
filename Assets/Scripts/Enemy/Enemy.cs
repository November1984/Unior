using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1f;

    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Talker _talker;
    private bool _canTalk;
    private Chaser _chaser;
    private bool _canChase;

    public float TalkDistance => _canTalk ? _talker.TalkDistance : -1;
    public bool IsTalking => _canTalk ? _talker.IsTalking : false;
    public bool IsPlayerSpotted => _canChase ? _chaser.IsPlayerSpotted : false;
    public bool IsClosePosition => _canChase ? _chaser.IsClosePosition : false;
    public Player SpottedPlayer => _canChase ? _chaser.SpottedPlayer : null;

    private void Awake()
    {
        _canTalk = TryGetComponent<Talker>(out _talker);
        _canChase = TryGetComponent<Chaser>(out _chaser);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(WaypointsContainer path)
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, path, _unitAnimator);
    }

    public void MoveTo(Vector3 waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);
        _unitAnimator.MoveDirection = Math.Sign(waypoint.x - transform.position.x);
    }

    public void Talk(bool value)
    {
        if (_canTalk)
            _talker.Talk(value);
    }
}
