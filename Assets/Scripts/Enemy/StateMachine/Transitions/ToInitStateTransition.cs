public class ToInitStateTransition : Transition
{
    public ToInitStateTransition(State nextState) : base(nextState) { }

    protected override bool CanTransit()
    {
        return true;
    }
}