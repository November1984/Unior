using UnityEngine;
using System;

[RequireComponent(typeof(UnitMover))]

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointNumber = 0;
    private UnitMover _unitMover;
    private Vector2 _currentWaypointDistance;

    private void Awake()
    {
        _unitMover = GetComponent<UnitMover>();
    }

    private void Start()
    {
        transform.position = _waypoints[0].position;
        _unitMover.Idle();
    }

    private void Update()
    {
        _currentWaypointDistance = _waypoints[_currentWaypointNumber].position - transform.position;

        _unitMover.Move(GetDirection(_currentWaypointDistance.x));

        if (Vector2.SqrMagnitude(_currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Length;
    }

    private int GetDirection(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}