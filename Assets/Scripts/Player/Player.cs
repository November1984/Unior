using UnityEngine;

[RequireComponent(typeof(PlayerStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]

public class Player : Unit
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;


    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize()
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = GetComponent<PlayerStateMachineFactory>().Create(this, _unitAnimator);
    }


}