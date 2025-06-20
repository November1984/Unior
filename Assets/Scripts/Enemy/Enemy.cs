using UnityEngine;

[RequireComponent(typeof(EnemyStateMachineFactory))]

public class Enemy : Unit
{
    private StateMachine _stateMachine;

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(Path path)
    {
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, path);
    }

    public void MoveTo(Vector3 waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);
    }
}
