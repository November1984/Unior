using UnityEngine;

public class ToMoveStateTransition : Transition
{
    const string Horizontal = nameof(Horizontal);

    public ToMoveStateTransition(State nextState) : base(nextState)
    {
     }

    protected override bool CanTransit()
    {
        return Input.GetAxisRaw(Horizontal) != 0;
    }
}