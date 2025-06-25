public class ToIdleStateTransition : Transition
{
    private Unit _enemy;

    public ToIdleStateTransition(State nextState, Unit enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsOnGround;
    }
}