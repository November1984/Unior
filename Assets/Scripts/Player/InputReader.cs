using System;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Unit))]
public class InputReader : MonoBehaviour
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Fsm _fsm;
    private Unit _unit;
    private CharacterAnimator _characterAnimator;


    public event Action<float> PlayerMoved;
    public event Action<float> PlayerJumped;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _unit = GetComponent<Unit>();

        _fsm = new(ref PlayerMoved, ref PlayerJumped, _characterAnimator);

        _fsm.AddState(new IdleState(_fsm));
        _fsm.AddState(new MoveState(
                        _fsm,
                        _unit.Transform,
                        _unit.RunSpeed
                        ));
        _fsm.AddState(new JumpState(
                        _fsm,
                        _unit.Rigidbody,
                        _unit.JumpSpeed));
    }

    private void Start()
    {
        _fsm.SetState<IdleState>();
    }

    private void Update()
    {
        PlayerMoved?.Invoke(Input.GetAxisRaw(Horisontal));
        PlayerJumped?.Invoke(Input.GetAxisRaw(Vertical));
    }
}