public class ToTargetReachedStateTransition : Transition
{
    private readonly IPatroller _patroller;

    public ToTargetReachedStateTransition(State nextState, IPatroller patroller) : base(nextState)
    {
        _patroller = patroller;
    }

    protected override bool CanTransit()
    {
        return _patroller.IsWaypointReached;
    }
}