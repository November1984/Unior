using System.Collections.Generic;
using UnityEngine;

public class WaypointsContainer
{
    private const float CloseDistanceValue = 0.5f;
    private readonly Queue<Transform> _waypoints;

    public WaypointsContainer(IEnumerable<Transform> path)
    {
        _waypoints = new Queue<Transform>(path);
        NextWaypoint = _waypoints.Dequeue();
    }

    public Transform NextWaypoint { get; private set; }
    public float CloseDistance => CloseDistanceValue;

    public void EnqueueNextWaypoint()
    {
        _waypoints.Enqueue(NextWaypoint);

        NextWaypoint = _waypoints.Dequeue();
    }
}