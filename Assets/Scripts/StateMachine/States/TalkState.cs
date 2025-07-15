public class TalkState : State
{
    private readonly Unit _unit;
    private readonly UnitAnimator _unitAnimator;

    public TalkState(IStateChanger stateChanger, Unit unit, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unit = unit;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unit.Talk();
    }
}