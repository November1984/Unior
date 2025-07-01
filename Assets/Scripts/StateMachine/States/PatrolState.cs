public class PatrolState : State
{
    private readonly Enemy _enemy;
    private readonly UnitAnimator _unitAnimator;
    private readonly WaypointsContainer _waypointsContainer;

    public PatrolState(IStateChanger stateChanger, Enemy enemy, WaypointsContainer waypointsContainer, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _enemy = enemy;
        _unitAnimator = unitAnimator;
        _waypointsContainer = waypointsContainer;
    }

    protected override void OnUpdate()
    {
        _enemy.MoveTo(_waypointsContainer.NextWaypoint.position);
        _unitAnimator.MoveOnGround();
    }
}