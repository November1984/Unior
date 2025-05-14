using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private MovementInput _movementInput;

    private MovementAnimator _movementAnimator;
    private IMoveAble _unit;

    private void Awake()
    {
        _movementAnimator = GetComponent<MovementAnimator>();
        _unit = GetComponent<IMoveAble>();
    }

    private void Start()
    { _movementAnimator.Idle(); }

    private void OnEnable()
    {
        _movementInput.Jumping += JumpInput;
        _movementInput.Moving += MoveInput;
    }

    private void OnDisable()
    {
        _movementInput.Jumping -= JumpInput;
        _movementInput.Moving -= MoveInput;
    }

    public void JumpInput(float value)
    {
        if (_unit.IsOnGround)
        { _movementAnimator.Idle(); }
        else
        {
            if (value <= 0)
                _movementAnimator.Landing();
        }

        if (value > 0 && _unit.IsOnGround)
        {
            _unit.Rigidbody.linearVelocityY = _unit.JumpSpeed;

            _movementAnimator.Jump();
        }
    }

    public void Move(Vector2 finishPosition)
    {
        _unit.Transform.position = Vector2.MoveTowards(transform.position,
                                    finishPosition,
                                    _unit.RunSpeed * Time.deltaTime
                                    );

        _movementAnimator.Move(GetDirectionCode(finishPosition.x - _unit.Transform.position.x));
    }

    public void MoveInput(float value)
    {
        Vector2 direction = new(value, 0);
        _unit.Transform.Translate(_unit.RunSpeed * Time.deltaTime * direction);

        _movementAnimator.Move(GetDirectionCode(value));
    }

    private int GetDirectionCode(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}
