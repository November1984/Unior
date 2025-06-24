using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private readonly Queue<Transform> _waypoints;

    public Path(IEnumerable<Transform> path)
    {
        _waypoints = new Queue<Transform>(path);
        NextWaypoint = _waypoints.Dequeue();
    }

    public Transform NextWaypoint { get; private set; }
    public float CloseDistance { get; private set; } = 0.5f;

    public void MoveNextWaypoint()
    {
        _waypoints.Enqueue(NextWaypoint);

        NextWaypoint = _waypoints.Dequeue();
    }
}