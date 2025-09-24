public class ChaseState : State
{
    private readonly IChaser _chaser;
    private readonly UnitAnimator _unitAnimator;

    public ChaseState(IStateChanger stateChanger,
                      IChaser chaser,
                      UnitAnimator unitAnimator) : base(stateChanger)
    {
        _chaser = chaser;
        _unitAnimator = unitAnimator;
    }

    protected override void OnUpdate()
    {
        _unitAnimator.MoveDirection = _chaser.Chaser.MoveTo(_chaser.SpottedUnit.Position);
        
        _unitAnimator.MoveOnGround();
    }
}