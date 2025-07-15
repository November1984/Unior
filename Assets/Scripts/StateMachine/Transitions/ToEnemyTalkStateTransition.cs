using UnityEngine;
public class ToEnemyTalkStateTransition : Transition
{
    private readonly Enemy _enemy;

    public ToEnemyTalkStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        if (_enemy.SpottedPlayer)
        {
            Vector3 offset = _enemy.transform.position - _enemy.SpottedPlayer.transform.position;
            float sqrLength = offset.sqrMagnitude;

            return sqrLength < _enemy.TalkDistance * _enemy.TalkDistance;

        }

        return false;
    }
}