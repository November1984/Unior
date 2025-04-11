using System;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    public event Action<Bus> FinishedRoute;
    private List<Vector3> _waypoints;
    private int _currentWaypoint;

    private void OnEnable()
    {
        _currentWaypoint = 0;
        transform.position = _waypoints[_currentWaypoint];
    }

    private void Update()
    {
        if (_currentWaypoint < _waypoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);

            if (transform.position == _waypoints[_currentWaypoint])
            { ++_currentWaypoint; }
        }
        else
            FinishedRouteNotify(this);
    }

    public void SetRoute(List<Vector3> waypoints)
    {
        _waypoints = waypoints;
    }

    private void FinishedRouteNotify(Bus bus)
    {
        FinishedRoute?.Invoke(bus);
    }
}