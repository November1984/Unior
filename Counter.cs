using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    public event Action CounterUpdated;
    public int Value {get; private set;}

    private IEnumerator _iterator;
    private Coroutine _coroutine;
    private bool _isStoped;

    private void Start()
    {
        Value = 0;
        _isStoped = true;
        _iterator = Count(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isStoped)
            {
                _coroutine = StartCoroutine(_iterator);
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
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            ++Value;
            CounterUpdated?.Invoke();
            yield return wait;
        }
    }
}

