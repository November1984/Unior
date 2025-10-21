public class AttackState : State
{
    private readonly IAttacker _attacker;
    private readonly UnitAnimator _unitAnimator;

    public AttackState(IStateChanger stateChanger, IAttacker attacker, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _attacker = attacker;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unitAnimator?.Attacking();
        _attacker?.Attack();
    }
}