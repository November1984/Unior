public class ToChaseStateTransition : Transition
{
    private readonly Enemy _enemy;
    
    public ToChaseStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsPlayerSpotted && !_enemy.IsClosePosition;
    }
}