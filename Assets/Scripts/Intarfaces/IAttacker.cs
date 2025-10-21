public interface IAttacker : IContactor
{
    public Attacker Attacker { get; }
    public bool IsUnitAutoAttacking { get; }

    public void Attack()
    {
        Attacker.Attack();
    }
}