public class ToVampireStateTransition : Transition
{
    private readonly IVampire _unit;

    public ToVampireStateTransition(State nextState, IVampire unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsVampiring == false;
    }
}