using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]

public class Enemy : Unit
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(Path path)
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, path, _unitAnimator);
    }

    public void MoveTo(Vector3 waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);

        _unitAnimator.MoveDirection = Math.Sign(waypoint.x - transform.position.x);
    }
}
