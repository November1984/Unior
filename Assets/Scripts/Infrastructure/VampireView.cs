using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampireView : MonoBehaviour
{
    private const float MinimumValue = 0.0001f;
    private const float MaximumValue = 1f;

    [SerializeField] private float _timerStep = 1;
    [SerializeField] private float _aciveTime = 6;
    [SerializeField] private float _chargingTime = 4;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = _aciveTime;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public bool Launch()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Decrease());
            return true;
        }

        return false;
    }

    private IEnumerator Increase()
    {
        var wait = new WaitForSecondsRealtime(_timerStep);
        float value = Mathf.Clamp(_chargingTime, MinimumValue, _chargingTime);
        float timer = MinimumValue;

        while (_slider.value < MaximumValue)
        {
            _slider.value = timer / value;

            yield return wait;

            timer += _timerStep * Time.deltaTime;
        }

        _coroutine = null;
    }

    private IEnumerator Decrease()
    {
        var wait = new WaitForSecondsRealtime(_timerStep);
        float value = Mathf.Clamp(_chargingTime, _chargingTime, MaximumValue);
        float timer = MaximumValue;

        while (_slider.value > MinimumValue)
        {
            _slider.value = timer / value;

            yield return wait;

            timer -= _timerStep * Time.deltaTime;
        }

        _coroutine = StartCoroutine(Increase());
    }
}
