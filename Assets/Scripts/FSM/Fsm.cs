using System;
using System.Collections.Generic;

public class Fsm
{
    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();
    private FsmState _stateCurrent;

    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (_stateCurrent != null && _stateCurrent.GetType() == type)
        {
            return;
        }

        if (_states.TryGetValue(type, out FsmState newState))
        {
            _stateCurrent?.Exit();
            _stateCurrent = newState;
            _stateCurrent.Enter();
        }
    }

    public void Update()
    {
        _stateCurrent?.Update();
    }
}