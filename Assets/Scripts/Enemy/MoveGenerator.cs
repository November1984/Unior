using UnityEngine;

public class MoveGenerator : MonoBehaviour
{
    [SerializeField] private float _closeRange = 0.1f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Mover _mover;

    private int _currentWaypointNumber = 0;
    private Vector2 _currentWaypointDistance;

    private void Start() => transform.position = _waypoints[0].position;

    private void Update()
    {
        _currentWaypointDistance = transform.position - _waypoints[_currentWaypointNumber].position;

        _mover.Move(_waypoints[_currentWaypointNumber].position);

        if (Vector2.SqrMagnitude(_currentWaypointDistance) < _closeRange)
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Length;
    }
}