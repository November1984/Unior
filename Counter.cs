using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputData;
    [SerializeField] private float _delay = 0.5f;

    private IEnumerator _coroutine;
    private int _value;
    private bool _isStoped;

    private void Start()
    {
        _value = 0;
        _outputData.text = "";
        _isStoped = true;
        _coroutine = Count(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isStoped)
            {
                StartCoroutine(_coroutine);
                _isStoped = false;
            }
            else
            {
                StopCoroutine(_coroutine);
                _isStoped = true;
            }
        }
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            DisplayCounter(++_value);
            yield return wait;
        }
    }

    private void DisplayCounter(int value)
    {
        _outputData.text = value.ToString("");
    }
}
