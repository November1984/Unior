public class ToJumpStateTransition : Transition
{
    private readonly Unit _unit;

    public ToJumpStateTransition(State nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsOnGround && _unit.Movement.JumpInput != 0;
    }
}