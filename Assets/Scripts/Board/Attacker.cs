using UnityEngine;

[RequireComponent(typeof(IAttacker))]
[RequireComponent(typeof(InputReader))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

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
        _bulletSpawner.GetObj(_unit.BasketBullets.transform).SetParams(transform.position, _unit.GetAttackDirection(), _unit.Speed);
    }
}