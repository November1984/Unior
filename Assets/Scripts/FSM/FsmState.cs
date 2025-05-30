public abstract class FsmState
{
    protected readonly Fsm _fsm;
    protected readonly CharacterAnimator _characterAnimator;

    public FsmState(Fsm fsm)
    {
        _fsm = fsm;
        _characterAnimator = _fsm.CharacterAnimator;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}