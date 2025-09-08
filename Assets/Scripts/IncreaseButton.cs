using UnityEngine;

public class IncreaseButton : ActionButton
{
    [SerializeField] private float _impactValue = 0f;

    protected override void Affect()
    {
        _health.Increase(_impactValue);
    }
}