using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : Healthbar
{
    [SerializeField] private float _fillingSpeed = 1f;

    private Slider _slider;
    private bool _canChange = false;
    private float _targetValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (_canChange)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _fillingSpeed);
            _canChange = _slider.value != _targetValue;
        }
    }

    protected override void Change(float value)
    {
        _targetValue = _slider.value + value;
        _canChange = true;

        base.Change(value);
    }
}