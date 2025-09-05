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

    protected override void Change(float value)
    {
        _slider.value += value;

        base.Change(value);
    }
}