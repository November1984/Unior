public class MoveState : State
{
    private readonly Unit _unit;

    public MoveState(IStateChanger stateChanger, Unit unit) : base(stateChanger)
    {
        _unit = unit;
    }

    public override void Enter()
    {
        _unit.Moved += Move;
    }

    public override void Exit()
    {
        _unit.Moved -= Move;
    }

    private void Move(int direction)
    {
        _unit.Move(direction);
    }
}