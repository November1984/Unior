using UnityEngine;

public class FsmStateRun : FsmStateMovement
{
    public FsmStateRun(
                Fsm fsm,
                Unit unit,
                float runSpeed,
                float jumpSpeed,
                MovementAnimator movementAnimator) : base(fsm, unit, runSpeed, jumpSpeed, movementAnimator) { }

    public override void Update()
    {
        float inputDirection = Input.GetAxisRaw(Horizontal);

        if (inputDirection == 0f)
        {
            _fsm.SetState<FsmStateIdle>();
            return;
        }

        if (Input.GetAxisRaw(Vertical) > 0)
        {
            _fsm.SetState<FsmStateJump>();
            return;
        }

        Move(inputDirection);
    }
}