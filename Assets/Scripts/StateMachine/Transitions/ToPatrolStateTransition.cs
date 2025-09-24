public class ToPatrolStateTransition : Transition
{
    private readonly IPatroller _patroller;

    public ToPatrolStateTransition(State nextState, IPatroller patroller) : base(nextState)
    {
        _patroller = patroller;
    }

    protected override bool CanTransit()
    {
        return _patroller.CanPatrol && _patroller.IsUnitSpotted == false;
    }
}