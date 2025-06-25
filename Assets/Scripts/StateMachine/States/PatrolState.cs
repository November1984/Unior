public class PatrolState : State
{
    private readonly Enemy _enemy;
    private readonly Path _path;

    public PatrolState(IStateChanger stateChanger, Enemy enemy, Path path) : base(stateChanger)
    {
        _enemy = enemy;
        _path = path;
    }

    protected override void OnUpdate()
    {
        _enemy.MoveTo(_path.NextWaypoint.position);
    }
}