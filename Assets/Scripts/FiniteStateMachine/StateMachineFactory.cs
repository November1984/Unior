using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Unit))]
public class StateMachineFactory : MonoBehaviour
{
    private CharacterAnimator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
    }

    public StateMachine Create(Enemy unit, Path path)
    {
        StateMachine stateMachine = new();

        stateMachine.AddState(new IdleState(
                        stateMachine,
                        unit,
                        _characterAnimator
                        ));
        stateMachine.AddState(new MoveState(
                        stateMachine,
                        unit,
                        _characterAnimator
                        ));
        stateMachine.AddState(new JumpState(
                        stateMachine,
                        unit,
                        _characterAnimator
                        ));

        stateMachine.SetState<IdleState>();
        return new StateMachine();
    }
}