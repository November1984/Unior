using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerView _timerView;
    
    private Coroutine _coroutine;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch(float value)
    {
        _coroutine = StartCoroutine(CountDown(value));
    }

    public IEnumerator CountDown(float value)
    {
        const int RoundSize = 2;
        
        float viewValue;
        
        while (value > 0)
        {
            value -= Time.deltaTime;
            viewValue = MathF.Round(value, RoundSize);

            _timerView?.Show(viewValue);

            yield return null;
        }
    }
}
