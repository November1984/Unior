using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IAutoAttacker))]
public class AutoAttacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _fireDelay = 2f;
    [SerializeField] private LayerMask _bulletsLayerMask;

    private float _gunOffset = 1f;
    private IAutoAttacker _unit;
    private Coroutine _coroutine;

    private void Awake()
    {
        _unit = GetComponent<IAutoAttacker>();
    }

    private void OnEnable()
    {
        _unit.Placed += Launch;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _unit.Placed -= Launch;
    }

    public void Launch()
    {
        _coroutine = StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        WaitForSecondsRealtime wait = new(_fireDelay);
        Vector3 bulletSpawnPoint;
        Bullet bullet;

        while (_unit.CanAttack)
        {
            bulletSpawnPoint = transform.position + _gunOffset * Vector3.left;
            bullet = _bulletSpawner.GetObj(_unit.BasketBullets.transform);
            bullet.SetParams(bulletSpawnPoint, _unit.GetAttackDirection(), _unit.Speed);

            bullet.gameObject.layer = 3;

            yield return wait;
        }
    }
}