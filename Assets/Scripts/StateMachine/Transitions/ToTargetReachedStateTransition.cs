using UnityEngine;

public class ToTargetReachedStateTransition : Transition
{
    private readonly Enemy _enemy;
    private readonly WaypointsContainer _waypointsContainer;

    public ToTargetReachedStateTransition(State nextState, Enemy enemy, WaypointsContainer waypointsContainer) : base(nextState)
    {
        _enemy = enemy;
        _waypointsContainer = waypointsContainer;
    }

    protected override bool CanTransit()
    {
        Vector3 offset = _enemy.transform.position - _waypointsContainer.NextWaypoint.position;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _waypointsContainer.CloseDistance * _waypointsContainer.CloseDistance;
    }
}