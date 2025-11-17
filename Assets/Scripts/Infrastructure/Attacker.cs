using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IAttacker))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _fireDelay = 2f;

    private IAttacker _unit;
    private Coroutine _coroutine;

    private void Awake()
    {
        _unit = GetComponent<IAttacker>();
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

            _bulletSpawner.GetObj(transform).SetPosition(gameObject.transform.position, _unit.GetAttackDirection());
        }
    }
}