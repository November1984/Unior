using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private IEnumerator _coroutine;
    private CounterView _view;
    private int _value;
    private bool _isStoped;

    private void Start()
    {
        _value = 0;
        _isStoped = true;
        _view = FindAnyObjectByType<CounterView>();
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
            _view.DisplayCounter(++_value);
            yield return wait;
        }
    }
}

