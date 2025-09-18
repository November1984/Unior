public class TargetReachedState : State
{
    private readonly WaypointsContainer _waypointsContainer;

    public TargetReachedState(IStateChanger stateMachine, WaypointsContainer waypointsContainer) : base(stateMachine)
    {
        _waypointsContainer = waypointsContainer;
    }

    public override void Enter()
    {
        _waypointsContainer.EnqueueNextWaypoint();
    }
}