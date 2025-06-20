
using UnityEngine;

public class ToTargetReachedStateTransition : Transition
{
    private readonly Enemy _enemy;
    private readonly Path _path;

    public ToTargetReachedStateTransition(State nextState, Enemy enemy, Path path) : base(nextState)
    {
        _enemy = enemy;
        _path = path;
    }

    protected override bool CanTransit()
    {
        Vector3 offset = _enemy.transform.position - _path.NextWaypoint.position;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _path.CloseDistance * _path.CloseDistance;
    }
}