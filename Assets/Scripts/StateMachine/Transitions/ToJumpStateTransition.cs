public class ToJumpStateTransition : Transition
{
    private readonly Player _unit;

    public ToJumpStateTransition(State nextState, Player unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsOnGround && _unit.Movement?.JumpInput != 0;
    }
}