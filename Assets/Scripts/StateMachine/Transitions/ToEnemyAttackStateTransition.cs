using UnityEngine;
public class ToEnemyAttackStateTransition : Transition
{
    private readonly Enemy _enemy;

    public ToEnemyAttackStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        Vector3 offset = _enemy.transform.position - _enemy.SpottedPlayer.transform.position;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _enemy.HitDistance * _enemy.HitDistance;
    }
}