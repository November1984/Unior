using System;
using System.Collections;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    public event Action Shot;
    private Coroutine _coroutine;
    private bool _canShoot;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch(float fireDelay)
    {
        _canShoot = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fire(fireDelay));
    }

    public void StopShoot()
    {
        _canShoot = false;
    }

    private IEnumerator Fire(float fireDelay)
    {
        WaitForSecondsRealtime wait = new(fireDelay);

        while (_canShoot)
        {
            Shot?.Invoke();

            yield return wait;
        }
    }
}