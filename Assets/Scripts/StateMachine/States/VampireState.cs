public class VampireState : State
{
    private readonly IVampire _unit;

    public VampireState(IStateChanger stateChanger, IVampire unit) : base(stateChanger)
    {
        _unit = unit;
    }

    public override void Enter()
    {
        _unit.Vamp();
    }
}