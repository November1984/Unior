public abstract class FsmState
{
    protected readonly FiniteStateMachine _fsm;

    public FsmState(FiniteStateMachine fsm)
    {
        _fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}