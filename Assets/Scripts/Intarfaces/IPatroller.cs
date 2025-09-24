public interface IPatroller
{
    public Patroller Patroller { get; }
    public bool CanPatrol { get; }
    public bool IsUnitSpotted { get; }
    public bool IsWaypointReached { get; }
}