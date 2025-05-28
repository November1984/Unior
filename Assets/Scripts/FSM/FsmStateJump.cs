using UnityEngine;

public class FsmStateJump : FsmStateMovement
{
    public FsmStateJump(
                    Fsm fsm,
                    Unit unit,
                    float runSpeed,
                    float jumpSpeed,
                    MovementAnimator movementAnimator) : base(fsm, unit, runSpeed, jumpSpeed, movementAnimator) { }

    public override void Update()
    {
        float elevation = Input.GetAxisRaw(Vertical);
        float direction = Input.GetAxisRaw(Horizontal);

        if (direction != 0)
            Move(direction);
        
        if (elevation > 0)
            Jump();
        else
            Land();
    }
}