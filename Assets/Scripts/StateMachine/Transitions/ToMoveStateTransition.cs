public class ToMoveStateTransition : Transition
{
    private readonly Unit _unit;

    public ToMoveStateTransition(State nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.Movement.MoveInput != 0;
    }
}