using UnityEngine;

public class MoveState : FsmState
{
    private readonly Transform _transform;
    private readonly float _runSpeed;

    public MoveState(Fsm fsm, Transform transform, float runSpeed) : base(fsm)
    {
        _transform = transform;
        _runSpeed = runSpeed;
    }

    public override void Enter()
    {
        _characterAnimator.Move(_fsm.MoveDirection);
    }

    public override void Update()
    {
        if (_fsm.MoveDirection == 0)
        {
            _fsm.SetState<IdleState>();
            return;
        }

        Vector2 direction = new(_fsm.MoveDirection, 0);
        _transform.Translate(_runSpeed * Time.deltaTime * direction);
        _characterAnimator.Move(_fsm.MoveDirection);
    }
}