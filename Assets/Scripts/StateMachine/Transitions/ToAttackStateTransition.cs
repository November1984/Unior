public class ToAttackStateTransition : Transition
{
    private readonly IAttacker _attacker;

    public ToAttackStateTransition(State nextState, IAttacker attacker) : base(nextState)
    {
        _attacker = attacker;
    }

    protected override bool CanTransit()
    {
        return _attacker.IsUnitAutoAttacking;
    }
}