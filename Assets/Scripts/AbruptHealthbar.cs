using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AbruptHealthbar : HealthView
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void Change(float value, float delta)
    {
        _slider.value = value;
    }
}