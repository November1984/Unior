public class JumpState : State
{
    private readonly Player _unit;
    private readonly UnitAnimator _unitAnimator;

    public JumpState(IStateChanger stateChanger, Player unit, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unit = unit;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        Jump(_unit.Movement.JumpInput);
    }

    private void Jump(int value)
    {
        if (value > 0)
        {
            _unit.Movement.Jump();
            _unitAnimator.Jumping();
        }
    }
}