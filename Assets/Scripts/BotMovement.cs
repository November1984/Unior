using System;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    private ActionAnimator _movementAnimator;
    private IMoveAble _unit;

    private void Awake()
    {
        _movementAnimator = GetComponent<ActionAnimator>();
        _unit = GetComponent<IMoveAble>();
    }

    private void Start()
    { _movementAnimator.Idle(); }

    public void Move(Vector2 finishPosition)
    {
        _unit.Transform.position = Vector2.MoveTowards(transform.position,
                                    finishPosition,
                                    _unit.RunSpeed * Time.deltaTime
                                    );

        _movementAnimator.Move(GetDirectionCode(finishPosition.x - _unit.Transform.position.x));
    }

    private int GetDirectionCode(float value)
    { return (value == 0) ? 0 : Math.Sign(value); }
}
