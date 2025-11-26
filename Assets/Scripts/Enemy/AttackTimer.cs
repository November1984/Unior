using System;
using System.Collections;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    private Coroutine _coroutine;
    private bool _canShoot;

    public event Action Triggered;

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
            Triggered?.Invoke();

            yield return wait;
        }
    }
}