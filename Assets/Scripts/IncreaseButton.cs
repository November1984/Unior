using UnityEngine;

public class IncreaseButton : ActionButton
{
    [SerializeField, Range(0f, 100f)] private float _impactValue = 0f;

    protected override void Affect()
    {
        Health.Increase(_impactValue);
    }
}