using UnityEngine;

public class ToJumpStateTransition : Transition
{
    const string Vertical = nameof(Vertical);

    private readonly Unit _unit;

    public ToJumpStateTransition(State nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsOnGround && Input.GetAxisRaw(Vertical) != 0;
    }
}