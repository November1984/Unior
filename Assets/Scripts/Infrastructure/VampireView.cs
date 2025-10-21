using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(RectTransform))]
public class VampireView : MonoBehaviour
{
    private const float MinValue = 0.0001f;
    private const float MaxValue = 1f;

    [SerializeField, Min(0)] private float _aciveTime = 6f;
    [SerializeField, Min(0)] private float _chargingTime = 4f;
    [SerializeField] private float _vampRadius = 2f;

    private Slider _slider;
    private Coroutine _coroutine;
    private RectTransform _rectTransform;

    public bool IsActive { get; private set; } = false;
    public float VampRadius => _vampRadius;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _slider.value = _aciveTime;
        _slider.minValue = MinValue;
        _slider.maxValue = MaxValue;
        _rectTransform.sizeDelta = new Vector2(_vampRadius, _vampRadius);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch()
    {
        if (_coroutine == null)
        {
            IsActive = true;
            _coroutine = StartCoroutine(Decrease());
        }
    }

    private IEnumerator Increase()
    {
        float speed = MaxValue / _chargingTime;

        while (_slider.value < MaxValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, MaxValue, speed * Time.deltaTime);

            yield return null;
        }

        StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private IEnumerator Decrease()
    {
        float speed = MaxValue / _aciveTime;

        while (_slider.value > MinValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, MinValue, speed * Time.deltaTime);

            yield return null;
        }

        StopCoroutine(_coroutine);
        
        IsActive = false;
        _coroutine = StartCoroutine(Increase());
    }
}
