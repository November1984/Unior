public abstract class State
{
    protected readonly StateMachine _fsm;

    public State(StateMachine fsm)
    {
        _fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update()
    {
        OnUpdate();
    }
    public virtual void OnUpdate() { }
}