// using UnityEngine;

// [RequireComponent(typeof(CharacterAnimator))]
// [RequireComponent(typeof(Unit))]
// public class FsmMovement : MonoBehaviour
// {
//     private Fsm _fsm;
//     private Unit _unit;
//     private CharacterAnimator _characterAnimator;

//     private void Awake()
//     {
//         _characterAnimator = GetComponent<CharacterAnimator>();
//         _unit = GetComponent<Unit>();
//     }

//     private void Start()
//     {
//         _fsm = new(ref PlayerMoved, ref PlayerJumped, _characterAnimator);

//         _fsm.AddState(new IdleState(_fsm));
//         _fsm.AddState(new MoveState(
//                         _fsm,
//                         _unit.Transform,
//                         _unit.RunSpeed
//                         ));
//         _fsm.AddState(new JumpState(
//                         _fsm,
//                         _unit.Rigidbody,
//                         _unit.JumpSpeed));

//         _fsm.SetState<IdleState>();
//     }

//     private void ReadInput()
//     {
        
//     }
// }