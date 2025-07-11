using UnityEngine;
public class ToPlayerAttackStateTransition : Transition
{
    private readonly Player _player;

    public ToPlayerAttackStateTransition(State nextState, Player player) : base(nextState)
    {
        _player = player;
    }

    protected override bool CanTransit()
    {
        return _player.IsHitting;
    }
}