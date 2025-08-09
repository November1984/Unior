using UnityEngine;

public class ToPatrolStateTransition : Transition
{
    private readonly Enemy _enemy;
    private readonly WaypointsContainer _waypointsContainer;

    public ToPatrolStateTransition(State nextState, Enemy enemy, WaypointsContainer waypointsContainer) : base(nextState)
    {
        _enemy = enemy;
        _waypointsContainer = waypointsContainer;
    }

    protected override bool CanTransit()
    {
        Vector3 offset = _enemy.transform.position - _waypointsContainer.NextWaypoint.position;
        float sqrLength = offset.sqrMagnitude;

        return _enemy.IsOnGround && _enemy.IsPlayerSpotted == false && sqrLength > _waypointsContainer.CloseDistance * _waypointsContainer.CloseDistance;
    }
}