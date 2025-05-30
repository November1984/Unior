using System;
using System.Collections.Generic;

public class Fsm
{
    private FsmState _currentState;
    private Dictionary<Type, FsmState> _states = new();

    public Fsm(
        ref Action<float> move,
        CharacterAnimator characterAnimator
        )
    {
        move += ReadMoveInput;
        CharacterAnimator = characterAnimator;
    }

    public Fsm(
            ref Action<float> move,
            ref Action<float> jump,
            CharacterAnimator characterAnimator
            )
    {
        move += ReadMoveInput;
        jump += ReadJumpInput;
        CharacterAnimator = characterAnimator;
    }

    public float MoveDirection { get; private set; }
    public float JumpDirection { get; private set; }
    public bool IsOnGround { get; private set; }
    public  CharacterAnimator CharacterAnimator { get; private set; }

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

    private void ReadMoveInput(float value)
    {
        MoveDirection = value;

        _currentState?.Update();
    }

    private void ReadJumpInput(float value)
    {
        JumpDirection = value;

        _currentState?.Update();
    }
}