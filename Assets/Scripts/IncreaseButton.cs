using UnityEngine;

public class IncreaseButton : ActionButton
{
    [SerializeField, Range(0f, 100f)] private float _impactValue = 0f;

    protected override void Affect()
    {
        if (_impactValue >= 0)
            Health.ChangeValue(_impactValue);
    }
}