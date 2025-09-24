public class PatrolState : State
{
    private readonly IPatroller _patroller;
    private readonly UnitAnimator _unitAnimator;
    private readonly WaypointsContainer _waypointsContainer;

    public PatrolState(IStateChanger stateChanger, IPatroller patroller, WaypointsContainer waypointsContainer, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _patroller = patroller;
        _unitAnimator = unitAnimator;
        _waypointsContainer = waypointsContainer;
    }

    public override void Enter()
    {
        Move();
    }

    protected override void OnUpdate()
    {
        Move();
    }

    private void Move()
    {
        _unitAnimator.MoveDirection = _patroller.Patroller.MoveTo(_waypointsContainer.NextWaypoint.position);
        
        _unitAnimator.MoveOnGround();
    }
}