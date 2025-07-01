using System.Collections.Generic;
using UnityEngine;

public class WaypointsContainer
{
    private readonly Queue<Transform> _waypoints;

    public WaypointsContainer(IEnumerable<Transform> path)
    {
        _waypoints = new Queue<Transform>(path);
        NextWaypoint = _waypoints.Dequeue();
    }

    public Transform NextWaypoint { get; private set; }
    public float CloseDistance { get; private set; } = 0.5f;

    public void SetNextWaypoint()
    {
        _waypoints.Enqueue(NextWaypoint);

        NextWaypoint = _waypoints.Dequeue();
    }
}