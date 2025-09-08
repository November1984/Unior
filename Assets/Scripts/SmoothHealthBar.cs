using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthbarSlider
{
    [SerializeField] private float _fillingDelay = 0.01f;
    [SerializeField] private float _fillingStep = 1f;

    private Coroutine _coroutine;

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(_coroutine);
    }

    protected override void Change(float value, float delta)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(RunChanger(value));
        base.Change(value, delta);
    }

    private IEnumerator RunChanger(float value)
    {
        var wait = new WaitForSecondsRealtime(_fillingDelay);

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _fillingStep);

            yield return wait;
        }
    }
}