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
        if (_fsm.IsOnGround)
            _characterAnimator.Move(_fsm.MoveDirection);
    }

    public override void Update()
    {
        if (_fsm.MoveDirection == 0)
        {
            _fsm.SetState<IdleState>();
            return;
        }

        if (_fsm.JumpDirection > 0)
            _fsm.SetState<JumpState>();

        Vector2 direction = new(_fsm.MoveDirection, 0);
        _transform.Translate(_runSpeed * Time.deltaTime * direction);

        if (_fsm.IsOnGround)
            _characterAnimator.Move(_fsm.MoveDirection);
    }
}