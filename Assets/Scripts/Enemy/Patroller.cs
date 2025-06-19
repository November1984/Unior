using UnityEngine;
using System;

[RequireComponent(typeof(Unit))]

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointNumber = 0;
    private Vector2 _currentWaypointDistance;
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        _currentWaypointDistance = _waypoints[_currentWaypointNumber].position - transform.position;

        _unit.MoveNotify(GetDirection(_currentWaypointDistance.x));

        if (Vector2.SqrMagnitude(_currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Length;
    }

    private int GetDirection(float value)
    {
        return (value == 0) ? 0 : Math.Sign(value);
    }
}