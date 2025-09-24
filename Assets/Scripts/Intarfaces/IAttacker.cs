public interface IAttacker : IContactor
{
    public Attacker Attacker { get; }
    public IDamageable AttackedUnit { get; }
    public bool IsUnitApproached { get; }

    public void Attack(IDamageable unit)
    {
        Attacker.Attack(unit);
    }
}