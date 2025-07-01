public class MoveState : State
{
    private readonly Unit _unit;
    private readonly UnitAnimator _unitAnimator;

    public MoveState(IStateChanger stateChanger, Unit unit, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unit = unit;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unit.Moved += Move;
    }

    public override void Exit()
    {
        _unit.Moved -= Move;
    }

    private void Move(int value)
    {
        _unit.Move(value);
        _unitAnimator.MoveDirection = value;

        if (_unit.IsOnGround)
            _unitAnimator.MoveOnGround();
    }
}