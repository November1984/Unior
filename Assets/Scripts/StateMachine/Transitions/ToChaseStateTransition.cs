public class ToChaseStateTransition : Transition
{
    private readonly IChaser _chaser;

    public ToChaseStateTransition(State nextState, IChaser chaser) : base(nextState)
    {
        _chaser = chaser;
    }

    protected override bool CanTransit()
    {
        return _chaser.SpottedUnit != null;
    }
}