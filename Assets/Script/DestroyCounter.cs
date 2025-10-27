using System;
using System.Collections;
using UnityEngine;

public class DestroyCounter : MonoBehaviour
{
    [SerializeField] private int _maxDestroyDelay = 5;
    [SerializeField] private Timer _timer;

    public event Action Finished;
    private Coroutine _coroutine;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartSelfDestroyCounter()
    {
        float delay = (float)GetRandomValue(_maxDestroyDelay);

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

    private double GetRandomValue(int maxValue)
    {
        return UnityEngine.Random.value * maxValue;
    }
}