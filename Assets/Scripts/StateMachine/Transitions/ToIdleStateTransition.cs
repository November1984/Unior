public class ToIdleStateTransition : Transition
{
    private readonly Unit _unit;

    public ToIdleStateTransition(State nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsOnGround &&
               _unit.Movement.MoveInput == 0 &&
               _unit.Movement.JumpInput == 0;
    }
}