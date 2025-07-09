public class TargetReachedState : State
{
    private readonly WaypointsContainer _waypointsContainer;

    public TargetReachedState(IStateChanger stateMachine, WaypointsContainer waypointsContainer) : base(stateMachine)
    {
        _waypointsContainer = waypointsContainer;
    }

    protected override void OnUpdate()
    {
        _waypointsContainer.EnqueueNextWaypoint();
    }
}