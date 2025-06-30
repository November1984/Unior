public class IdleState : State
{
    private readonly UnitAnimator _unitAnimator;

    public IdleState(IStateChanger stateChanger, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unitAnimator = unitAnimator;
    }

    protected override void OnUpdate()
    {
        _unitAnimator.Standing();
    }
}