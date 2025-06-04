using UnityEngine;

public class MoveState : FsmState
{
    private readonly Transform _transform;
    private readonly float _runSpeed;
    protected readonly CharacterAnimator _characterAnimator;

    public MoveState(FiniteStateMachine fsm, Transform transform, float runSpeed) : base(fsm)
    {
        _transform = transform;
        _runSpeed = runSpeed;
        _characterAnimator = _fsm.CharacterAnimator;
    }

    public override void Enter()
    {
        Debug.Log($"{this.GetType()} - Enter");
        if (_fsm.IsOnGround)
            _characterAnimator.GroundMove(_fsm.MoveDirection);
    }

    public override void Update()
    {
        if (_fsm.MoveDirection == 0)
        {
            Debug.Log($"{this.GetType()} - Exit");

            _fsm.SetState<IdleState>();
            return;
        }

        if (_fsm.JumpDirection > 0)
            _fsm.SetState<JumpState>();

        Vector2 direction = new(_fsm.MoveDirection, 0);
        _transform.Translate(_runSpeed * Time.deltaTime * direction);

        if (_fsm.IsOnGround)
        {
            Debug.Log($"{this.GetType()} - OnGround");

            _characterAnimator.GroundMove(_fsm.MoveDirection);
        }
        else
            _characterAnimator.Move(_fsm.MoveDirection);
    }
}