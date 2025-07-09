public class ChaseState : State
{
    private readonly Enemy _enemy;
    private readonly UnitAnimator _unitAnimator;

    public ChaseState(IStateChanger stateChanger,
                      Enemy enemy,
                      UnitAnimator unitAnimator) : base(stateChanger)
    {
        _enemy = enemy;
        _unitAnimator = unitAnimator;
    }

    protected override void OnUpdate()
    {
        _enemy.MoveTo(_enemy.SpottedPlayer.transform.position);
        _unitAnimator.MoveOnGround();
    }
}