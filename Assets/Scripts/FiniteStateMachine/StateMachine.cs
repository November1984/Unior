using System;
using System.Collections.Generic;
    
public class StateMachine
{
    private readonly Dictionary<Type, State> _states = new();
    private State _currentState;

      public void SetState<Type>() where Type : State
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

    public void AddState(State state)
    {
        _states.Add(state.GetType(), state);
    }

    public void Update()
    {
        _currentState?.Update();
    }
}