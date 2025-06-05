using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Unit))]
public class FiniteStateMachineFactory : MonoBehaviour
{
    private FiniteStateMachine _fsm;
    private CharacterAnimator _characterAnimator;
    private Unit _unit;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _unit = GetComponent<Unit>();
    }

    private void Start()
    {
        _fsm = new();

        _fsm.AddState(new IdleState(
                        _fsm,
                        _unit,
                        _characterAnimator
                        ));
        _fsm.AddState(new MoveState(
                        _fsm,
                        _unit,
                        _characterAnimator
                        ));
        _fsm.AddState(new JumpState(
                        _fsm,
                        _unit,
                        _characterAnimator
                        ));

        _fsm.SetState<IdleState>();
    }
}