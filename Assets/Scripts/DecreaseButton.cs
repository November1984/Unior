using UnityEngine;

public class DecreaseButton : ActionButton
{
    [SerializeField] private float _impactValue = 0f;

    protected override void Affect()
    {
        _health.Decrease(_impactValue);
    }
}