using UnityEngine;

public class ToIdleStateTransition : Transition
{
    const string Horizontal = nameof(Horizontal);
    const string Vertical = nameof(Vertical);

    private readonly Unit _enemy;

    public ToIdleStateTransition(State nextState, Unit enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsOnGround &&
               Input.GetAxisRaw(Horizontal) == 0 &&
               Input.GetAxisRaw(Vertical) == 0;
    }
}