public class ToIdleStateTransition : Transition
{
    private Enemy _enemy;

    public ToIdleStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsOnGround;
    }
}