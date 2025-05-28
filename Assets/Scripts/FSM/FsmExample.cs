using UnityEngine;

public class FsmExample : MonoBehaviour
{
    private Fsm _fsm;
    private float _walkSpeed = 3f;
    private float _jumpSpeed = 6f;

    private void Awake()
    {
        _fsm = new Fsm();

        _fsm.AddState(new FsmStateIdle(_fsm));
        _fsm.AddState(new FsmStateWalk(_fsm, transform, _walkSpeed));

        _fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        _fsm.Update();
    }
}