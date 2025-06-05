using System;
using System.Collections.Generic;
    
public class FiniteStateMachine
{
    private readonly Dictionary<Type, FsmState> _states = new();
    private FsmState _currentState;

      public void SetState<Type>() where Type : FsmState
    {
        var type = typeof(Type);

        if (_currentState != null && _currentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            _currentState?.Exit();

            _currentState = newState;

            _currentState.Enter();
        }
    }

    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void Update()
    {
        _currentState?.Update();
    }
}