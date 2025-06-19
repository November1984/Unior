using UnityEngine;

[RequireComponent(typeof(StateMachineFactory))]

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Initialize(Path path)
    {
        _stateMachine = GetComponent<StateMachineFactory>().Create(this, path);
    }
}
