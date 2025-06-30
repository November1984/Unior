using UnityEngine;

[RequireComponent(typeof(PlayerStateMachineFactory))]

public class Player : Unit
{
    private StateMachine _stateMachine;

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize()
    {
        _stateMachine = GetComponent<PlayerStateMachineFactory>().Create(this);
    }


}