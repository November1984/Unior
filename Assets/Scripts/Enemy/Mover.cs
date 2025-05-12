using System;
using System.Linq;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private float _speed = 1;

    public event Action<int> ObjectMoved;
    public event Action<bool> ObjectJumped;

    private int _currentWaypointNumber;

    private void Start()
    {
        _currentWaypointNumber = 0;
        transform.position = _waypoints[_currentWaypointNumber].position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                _waypoints[_currentWaypointNumber].position,
                                                _speed * Time.deltaTime
                                                );

        Vector2 currentWaypointDistance = transform.position - _waypoints[_currentWaypointNumber].position;

        SetMovingDirection(currentWaypointDistance);

        if (Vector2.SqrMagnitude(currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Count();
    }

    private void SetMovingDirection(Vector2 value)
    {
        if (value.x < 0)
        MovedNotify(1);
        else
        MovedNotify(-1);
    }

    private void MovedNotify(int value) => ObjectMoved?.Invoke(value);
}
