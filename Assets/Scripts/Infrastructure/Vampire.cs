using System;
using System.Collections;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    private const int MaxVampiredEnemies = 3;

    [SerializeField, Min(0)] private float _aciveTime = 6f;
    [SerializeField, Min(0)] private float _chargingTime = 4f;
    [SerializeField] private float _vampireForce = 5f;
    [SerializeField] private float _vampireSpeed = 0.5f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ContactFilter2D _enemiesLayer;
    [SerializeField] private float _vampRange = 2f;

    public event Action<float> Activated;
    public event Action<float> Rechargeded;

    private bool _isVampiring;
    private Coroutine _coroutine;
    private Collider2D[] _hitedEnemies = new Collider2D[3];

    public bool IsVampiring => _isVampiring;
    public float VampRange => _vampRange;

    private void OnEnable()
    {
        _inputReader.IsVampiring += Notify;
    }

    private void OnDisable()
    {
        _inputReader.IsVampiring -= Notify;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Suckout());
    }

    private void Notify(bool value)
    {
        _isVampiring = value;
    }

    private IEnumerator Suckout()
    {
        float timer = _aciveTime;
        float barFillment;

        var wait = new WaitForSecondsRealtime(_vampireSpeed);

        while (timer > 0)
        {
            timer -= wait.waitTime;
            barFillment = timer / _aciveTime;

            HitEnemy();

            Activated?.Invoke(barFillment);

            yield return wait;
        }

        StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        float timer = 0;
        float barFillment;

        while (timer < _chargingTime)
        {
            timer += Time.deltaTime;
            barFillment = timer / _chargingTime;

            Rechargeded?.Invoke(barFillment);

            yield return null;
        }

        StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private void HitEnemy()
    {
        int hitedEnemiesCount;
        float minimumDistance;
        float currentDistance;
        Collider2D closestEnemy = null;

        hitedEnemiesCount = Physics2D.OverlapCircle(transform.position, _vampRange, _enemiesLayer, _hitedEnemies);
        minimumDistance = float.PositiveInfinity;

        if (hitedEnemiesCount > 0)
        {
            for (int i = 0; i < hitedEnemiesCount; i++)
            {
                currentDistance = GetDistance(_hitedEnemies[i].transform.position);

                if (currentDistance < minimumDistance)
                {
                    closestEnemy = _hitedEnemies[i];
                    minimumDistance = currentDistance;
                }
            }

            closestEnemy.GetComponent<IDamageable>()?.Health.Decrease(_vampireForce);
        }
    }

    private float GetDistance(Vector3 obj)
    {
        Vector3 offset = transform.position - obj;

        return offset.sqrMagnitude;
    }
}