using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IAutoAttacker))]
public class AutoAttacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _fireDelay = 2f;

    private IAutoAttacker _unit;
    private Coroutine _coroutine;

    private void Awake()
    {
        _unit = GetComponent<IAutoAttacker>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Fire());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Fire()
    {
        WaitForSecondsRealtime wait = new(_fireDelay);

        while (true)
        {
            yield return wait;

            _bulletSpawner.GetObj(_unit.BasketBullets.transform).SetParams(transform.position, _unit.GetAttackDirection(), _unit.Speed);
        }
    }
}