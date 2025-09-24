using Unity.VisualScripting;

public interface IChaser
{
    public Chaser Chaser { get; }
    public IDamageable SpottedUnit { get; }
    public bool IsUnitApproached { get; }
    public bool IsUnitAttacked { get; }
}