using UnityEngine;

public class MoveState : State
{
    private readonly CharacterAnimator _characterAnimator;
    private readonly Unit _unit;

    private int _moveDirection;
    public MoveState(
            StateMachine fsm,
            Unit unit,
            CharacterAnimator characterAnimator
            ) : base(fsm)
    {
        _characterAnimator = characterAnimator;
        _unit = unit;
    }

    public override void Enter()
    {
        _unit.Moved += SetMoveDirection;
        _unit.Jumped += MakeJump;

        if (_unit.IsOnGround)
            _characterAnimator.GroundMove(_moveDirection);
    }

    public override void Update()
    {
        if (_unit.IsOnGround)
            _characterAnimator.GroundMove(_moveDirection);
        else
            _characterAnimator.Move(_moveDirection);

        Vector2 direction = new(_moveDirection, 0);
        _unit.Transform.Translate(_unit.RunSpeed * Time.deltaTime * direction);
    }

    public override void Exit()
    {
        _unit.Moved -= SetMoveDirection;
        _unit.Jumped -= MakeJump;
    }

    private void SetMoveDirection(int value)
    {
        if (value != 0)
        {
            _moveDirection = value;

            Update();
        }

        if (_unit.IsOnGround && value == 0)
            _fsm.SetState<IdleState>();
    }

    private void MakeJump(int value)
    {
        if (value != 0 && _unit.IsOnGround)
            _fsm.SetState<JumpState>();

        Update();
    }
}