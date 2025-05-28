using UnityEngine;

public class FsmStateIdle : FsmStateMovement
{
    public FsmStateIdle(Fsm fsm,
                    Unit unit,
                    float runSpeed,
                    float jumpSpeed,
                    MovementAnimator movementAnimator) : base(fsm, unit, runSpeed, jumpSpeed, movementAnimator) { }

    public override void Update()
    {
        if (Input.GetAxisRaw(Horizontal) != 0)
        {
            _fsm.SetState<FsmStateRun>();
            return;
        }
        else if (Input.GetAxisRaw(Vertical) != 0)
        {
            _fsm.SetState<FsmStateJump>();
            return;
        }

        Idle();
    }
}