public class EnemyTalkState : State
{
    private readonly Unit _unit;
    private readonly UnitAnimator _unitAnimator;

    public EnemyTalkState(IStateChanger stateChanger, Unit unit, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _unit = unit;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unitAnimator.TalkingEnemy();
    }
}