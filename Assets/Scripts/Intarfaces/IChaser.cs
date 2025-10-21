using Unity.VisualScripting;

public interface IChaser
{
    public Chaser Chaser { get; }
    public IDamageable SpottedUnit { get; }
    public IDamageable ApproachedUnit { get; }
    public bool IsUnitAutoAttacking { get; }
}