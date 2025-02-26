using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private bool _isStoped;
    private int _value;

    public event Action<int> Updated;

    private void Start()
    {
        _value = 0;
        _isStoped = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isStoped)
            {
                _coroutine = StartCoroutine(Count(_delay));
                _isStoped = false;
            }
            else
            {
                if (_coroutine != null)
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
            ++_value;
            Updated?.Invoke(_value);
            yield return wait;
        }
    }
}

