using UnityEngine;

[RequireComponent(typeof(IAttacker))]
[RequireComponent(typeof(InputReader))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private LayerMask _bulletsLayerMask;

    private float _gunOffset = 1f;
    private InputReader _inputReader;
    private IAttacker _unit;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _unit = GetComponent<IAttacker>();
    }

    private void OnEnable()
    {
        _inputReader.Attacking += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.Attacking -= Shoot;
    }

    private void Shoot()
    {
        Vector3 bulletSpawnPoint = transform.position + _gunOffset * Vector3.right;
        Bullet bullet = _bulletSpawner.GetObj(_unit.BasketBullets.transform);
        bullet.SetParams(bulletSpawnPoint, _unit.GetAttackDirection(), _unit.Speed);

        bullet.gameObject.layer = 0;
    }
}