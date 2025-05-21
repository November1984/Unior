using UnityEngine;
using System;

public class Patroller : MonoBehaviour, IMove, IIdle
{
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointNumber = 0;
    private Vector2 _currentWaypointDistance;

    public event Action<float> UnitMoved;
    public event Action UnitIdle;

    private void Start()
    {
        transform.position = _waypoints[0].position;
        UnitIdle?.Invoke();
    }

    private void Update()
    {
        _currentWaypointDistance = _waypoints[_currentWaypointNumber].position - transform.position;

        UnitMoved?.Invoke(GetDirection(_currentWaypointDistance.x));

        if (Vector2.SqrMagnitude(_currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Length;
    }

    private int GetDirection(float value)
    {
        return (value == 0) ? 0 : Math.Sign(value);
    }
}