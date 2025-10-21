using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    private const int MaxVampiredEnemies = 3;

    [SerializeField] VampireView _vampireView;
    [SerializeField] float _vampireForce = 5f;
    [SerializeField] float _vampireSpeed = 0.5f;
    [SerializeField] InputReader _inputReader;
    [SerializeField] ContactFilter2D _enemiesLayer;

    private bool _isVampiring;
    private Coroutine _coroutine;
    private Collider2D[] _hitedEnemies = new Collider2D[3];

    public bool IsVampiring => _isVampiring;

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
        _vampireView.Launch();

        _coroutine = StartCoroutine(Suckout());
    }

    private void Notify(bool value)
    {
        _isVampiring = value;
    }

    private IEnumerator Suckout()
    {
        float vampRange = _vampireView.VampRadius;
        float minimumDistance;
        float currentDistance;
        Collider2D closestEnemy = null;
        int hitedEnemiesCount;

        var wait = new WaitForSecondsRealtime(_vampireSpeed);

        while (_vampireView.IsActive)
        {
            hitedEnemiesCount = Physics2D.OverlapCircle(transform.position, vampRange, _enemiesLayer, _hitedEnemies);
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

            yield return wait;
        }
    }

    private float GetDistance(Vector3 obj)
    {
        Vector3 offset = transform.position - obj;

        return offset.sqrMagnitude;
    }
}