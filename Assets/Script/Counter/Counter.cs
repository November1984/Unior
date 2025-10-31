using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action Finished;
    private Coroutine _coroutine;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch(float delay)
    {
        _coroutine = StartCoroutine(CountDown(delay));
    }

    private IEnumerator CountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        StopCoroutine(_coroutine);
        Finished?.Invoke();
    }
}