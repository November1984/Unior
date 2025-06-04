using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(IUnitMover))]
[RequireComponent(typeof(Unit))]
public class FsmMovement : MonoBehaviour
{
    private FiniteStateMachine _fsm;
    private IUnitMover _unitMovement;
    private Unit _unit;
    private CharacterAnimator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _unitMovement = GetComponent<IUnitMover>();
        _unit = GetComponent<Unit>();
    }

    private void Start()
    {
        _fsm = new(_characterAnimator);

        _fsm.AddState(new IdleState(_fsm));
        _fsm.AddState(new MoveState(
                        _fsm,
                        _unit.Transform,
                        _unit.RunSpeed
                        ));
        _fsm.AddState(new JumpState(
                        _fsm,
                        _unit.Rigidbody,
                        _unit.JumpSpeed));

        _fsm.SetState<IdleState>();
    }

    private void OnEnable()
    {
        _unitMovement.UnitMoved += ReadMove;
        _unitMovement.UnitJumped += ReadJump;
    }

    private void OnDisable()
    {
        _unitMovement.UnitMoved -= ReadMove;
        _unitMovement.UnitJumped -= ReadJump;
    }

    private void ReadMove(float value)
    {
        _fsm.SetMoveInput(value, _unit.IsOnGround);
    }

    private void ReadJump(float value)
    {
        _fsm.SetJumpInput(value, _unit.IsOnGround);
    }
}