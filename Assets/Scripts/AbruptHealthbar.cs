using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AbruptHealthbar : Healthbar
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void Change(float value, float delta)
    {
        _slider.value = value;

        base.Change(value, delta);
    }
}