public class IdleState : State
{
    private readonly CharacterAnimator _characterAnimator;
    private Unit _unit;

    public IdleState(
                StateMachine fsm,
                Unit unit,
                CharacterAnimator characterAnimator
                ) : base(fsm)
    {
        _characterAnimator = characterAnimator;
        _unit = unit;
    }

    public override void Enter()
    {
        _unit.Jumped += OnJump;
        _unit.Moved += OnMove;

        _characterAnimator.Idle();
    }

    public override void Update()
    {}

    public override void Exit()
    {
        _unit.Jumped -= OnJump;
        _unit.Moved -= OnMove;
    }

    private void OnJump(int value)
    {
        if (value != 0)
            _fsm.SetState<JumpState>();
    }

    private void OnMove(int value)
    {
        if (value != 0)
            _fsm.SetState<MoveState>();
    }
}