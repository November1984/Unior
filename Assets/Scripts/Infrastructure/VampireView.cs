using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(RectTransform))]
public class VampireView : MonoBehaviour
{
    private const float MinSliderValue = 0.0001f;
    private const float MaxSliderValue = 1f;

    [SerializeField] private float _fillingDelay = 0.001f;

    public Vampire Vampire { get; set; }

    private Slider _slider;
    private Coroutine _coroutine;
    private RectTransform _rectTransform;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _slider.minValue = MinSliderValue;
        _slider.maxValue = MaxSliderValue;
        _rectTransform.sizeDelta = new Vector2(Vampire.VampRange, Vampire.VampRange);
    }

    public void Init()
    {
        Vampire.Activated += Decrease;
        Vampire.Rechargeded += Increase;
    }

    private void OnDisable()
    {
        if (Vampire != null)
        {
            Vampire.Activated -= Decrease;
            Vampire.Rechargeded -= Increase;
        }
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Increase(float newValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(IncreaseTimer(newValue));
    }

    private IEnumerator IncreaseTimer(float newValue)
    {
        var wait = new WaitForSecondsRealtime(_fillingDelay);
        float speed = newValue - _slider.value;

        while (_slider.value < newValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newValue, Time.deltaTime * speed);

            yield return wait;
        }
    }

    private void Decrease(float currentValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DecreaseTimer(currentValue));

    }

    private IEnumerator DecreaseTimer(float newValue)
    {
        var wait = new WaitForSecondsRealtime(_fillingDelay);
        float speed = _slider.value - newValue;

        while (_slider.value > newValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newValue, Time.deltaTime * speed);

            yield return wait;
        }
    }
}
