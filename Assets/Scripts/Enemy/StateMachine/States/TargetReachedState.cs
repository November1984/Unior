public class TargetReachedState : State
{
    private readonly Path _path;

    public TargetReachedState(IStateChanger stateMachine, Path path) : base(stateMachine)
    {
        _path = path;
    }

    protected override void OnUpdate()
    {
        _path.MoveNextWaypoint();
    }
}