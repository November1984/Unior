public interface IAttacker : IContactor
{
    public Attacker Attacker { get; }
    public bool IsUnitAttacked { get; }

    public void Attack()
    {
        Attacker.Attack();
    }
}