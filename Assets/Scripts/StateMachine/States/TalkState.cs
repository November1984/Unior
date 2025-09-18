public class TalkState : State
{
    private readonly Enemy _enemy;
    private readonly UnitAnimator _unitAnimator;

    public TalkState(IStateChanger stateChanger, Enemy enemy, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _enemy = enemy;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unitAnimator.TalkingEnemy();
        _enemy.Talk(true);
    }

    public override void Exit()
    {
        _enemy.Talk(false);
    }
}