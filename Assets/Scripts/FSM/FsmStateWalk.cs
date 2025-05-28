using UnityEngine;

public class FsmStateWalk : FsmStateMovement
{
    public FsmStateWalk(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

    public override void Update()
    {
        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
            _fsm.SetState<FsmStateIdle>();

        Move(inputDirection);
    }
}