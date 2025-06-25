using System;

public class StateMachine : IStateChanger
{
    private State _currentState;

    public Type CurrentState => _currentState.GetType();

    public void ChangeState(State nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        _currentState?.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }
}