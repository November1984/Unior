public abstract class Transition
{
    private readonly State _nextState;

    public Transition(State nextState)
    {
        _nextState = nextState;
    }

    public bool TryTransition(out State nextState)
    {
        nextState = _nextState;

        return CanTransit();
    }

    protected abstract bool CanTransit();
}