using UnityEngine;

public class DecreaseButton : ActionButton
{
    [SerializeField, Range(-100f, 0f)] private float _impactValue = 0f;

    protected override void Affect()
    {
        Health.Decrease(_impactValue);
    }
}