using System.Collections.Generic;

public abstract class State
{
    private readonly List<Transition> _transitions = new();
    private readonly IStateChanger _stateChanger;

    public State(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }
    
    public void AddTransition(Transition transition)
    {
        _transitions.Add(transition);
    }

    public virtual void Enter() { }

    public void Update()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.TryTransition(out State nextState) == false)
                continue;

            _stateChanger.ChangeState(nextState);

            return;
        }

        OnUpdate();
    }

    public virtual void Exit() { }
    protected virtual void OnUpdate() { }
}