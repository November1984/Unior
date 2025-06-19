using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private readonly Queue<Transform> _waypoints;

    public Path(IEnumerable<Transform> path)
    {
        _waypoints = new Queue<Transform>(path);
        NextPoint = _waypoints.Dequeue();
    }

    public Transform NextPoint { get; private set; }

    public void MoveNext()
    {
        _waypoints.Enqueue(NextPoint);

        NextPoint = _waypoints.Dequeue();
    }
}