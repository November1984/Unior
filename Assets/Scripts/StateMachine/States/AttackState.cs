public class AttackState : State
{
    private readonly Enemy _enemy;
    private readonly UnitAnimator _unitAnimator;

    public AttackState(IStateChanger stateChanger, Enemy enemy, UnitAnimator unitAnimator) : base(stateChanger)
    {
        _enemy = enemy;
        _unitAnimator = unitAnimator;
    }

    public override void Enter()
    {
        _unitAnimator.AttackingEnemy();
        _enemy.Attacker.Attack(_enemy.AttackedUnit);
    }

    public override void Exit()
    {
        _enemy.Attacker.StopAttack();
    }
}