using System;
using System.Collections;
using UnityEngine;

public class RandomCounter : MonoBehaviour
{
    public event Action Finished;
    private Coroutine _coroutine;
    private Timer _timer;

    private void Awake ()
    {
        TryGetComponent(out _timer);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch(float minDelay, float maxDelay)
    {
        float delay = GetRandomValue(minDelay, maxDelay);

        _timer?.Launch(delay);

        _coroutine = StartCoroutine(CountDown(delay));
    }

    private IEnumerator CountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        StopCoroutine(_coroutine);
        Finished?.Invoke();
    }

    private float GetRandomValue(float minDelay, float maxDelay)
    {
        return UnityEngine.Random.Range(minDelay, maxDelay);
    }
}