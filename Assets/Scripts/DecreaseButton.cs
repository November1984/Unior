using UnityEngine;

public class DecreaseButton : ActionButton
{
    [SerializeField, Range(-100f, 0f)] private float _impactValue = 0f;

    protected override void Affect()
    {
        if (_impactValue <= 0)
            Health.ChangeValue(_impactValue);
    }
}