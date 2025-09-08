using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AbruptHealthbar : HealthbarSlider
{
    protected override void Change(float value, float delta)
    {
        _slider.value = value;

        base.Change(value, delta);
    }
}