public class PatrolState : State
{
    private readonly Enemy _enemy;
    private readonly UnitAnimator _unitAnimator;
    private readonly Path _path;

    public PatrolState(IStateChanger stateChanger, Enemy enemy, Path path, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _enemy = enemy;
        _unitAnimator = unitAnimator;
        _path = path;
    }

    protected override void OnUpdate()
    {
        _enemy.MoveTo(_path.NextWaypoint.position);
        _unitAnimator.MoveOnGround();
    }
}