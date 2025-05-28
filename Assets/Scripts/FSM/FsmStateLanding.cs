using UnityEngine;

public class FsmStateLanding : FsmStateMovement
{
    public FsmStateLanding(
                Fsm fsm,
                Unit unit,
                float runSpeed,
                float jumpSpeed,
                MovementAnimator movementAnimator) : base(fsm, unit, runSpeed, jumpSpeed, movementAnimator) { }

    public override void Update()
    {
        float inputDirection = Input.GetAxisRaw(Vertical);

        if (inputDirection <= 0f)
            _fsm.SetState<FsmStateIdle>();
    }
}