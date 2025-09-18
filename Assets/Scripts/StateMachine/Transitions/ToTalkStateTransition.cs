using UnityEngine;
public class ToTalkStateTransition : Transition
{
    private readonly Enemy _enemy;

    public ToTalkStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsClosePosition;
    }
}