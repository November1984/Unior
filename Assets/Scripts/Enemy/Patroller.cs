using UnityEngine;
using System;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Unit))]

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private Transform[] _waypoints;

    private CharacterAnimator _characterAnimator;
    private int _currentWaypointNumber = 0;
    private Vector2 _currentWaypointDistance;
    private Fsm _fsm;
    private Unit _unit;

    public event Action<float> PlayerMoved;
    public event Action UnitIdle;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _unit = GetComponent<Unit>();

        _fsm = new(ref PlayerMoved, _characterAnimator);

        _fsm.AddState(new IdleState(_fsm));
        _fsm.AddState(new MoveState(_fsm, _unit.Transform, _unit.RunSpeed));
    }

    private void Start()
    {
        transform.position = _waypoints[0].position;
        UnitIdle?.Invoke();

        _fsm.SetState<IdleState>();

    }

    private void Update()
    {
        _currentWaypointDistance = _waypoints[_currentWaypointNumber].position - transform.position;

        PlayerMoved?.Invoke(GetDirection(_currentWaypointDistance.x));

        if (Vector2.SqrMagnitude(_currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Length;
    }

    private float GetDirection(float value)
    {
        return (value == 0) ? 0 : Math.Sign(value);
    }
}