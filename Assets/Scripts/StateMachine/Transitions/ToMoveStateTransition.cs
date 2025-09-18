public class ToMoveStateTransition : Transition
{
    private readonly Player _unit;

    public ToMoveStateTransition(State nextState, Player unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.Movement.MoveInput != 0;
    }
}