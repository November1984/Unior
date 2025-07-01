public class JumpState : State
{
    private readonly Unit _unit;
    private readonly UnitAnimator _unitAnimator;

    public JumpState(IStateChanger stateChanger, Unit unit, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unit = unit;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unit.Jumped += Jump;
    }

    public override void Exit()
    {
        _unit.Jumped -= Jump;
    }

    private void Jump(int value)
    {
        if (_unit.IsOnGround && value > 0)
        {
            _unit.Jump();
            _unitAnimator.Jumping();
        }
    }
}