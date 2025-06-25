public class JumpState : State
{
    private readonly Unit _unit;

    public JumpState(IStateChanger stateChanger, Unit unit) : base(stateChanger)
    {
        _unit = unit;
    }

    public override void Enter()
    {
        _unit.Jumped += Jump;
    }

    public override void Exit()
    {
        _unit.Jumped -= Jump;
    }

    private void Jump(int direction)
    {
        if (_unit.IsOnGround && direction > 0)
            _unit.Jump();
    }
}