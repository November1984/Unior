using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    private const int PoolCapacity = 15;
    private const int PoolMaxSize = 15;

    private ObjectPool<Enemy> _pool;
    private Enemy _enemy;
    private Enemy _prefab;
    private Vector3 _position;
    private Transform _path;

    private void Awake()
    {
        _pool = new(
                    createFunc: () => Create(),
                    actionOnGet: (obj) => Get(obj),
                    actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                    actionOnDestroy: (obj) => Destroy(obj),
                    collectionCheck: true,
                    defaultCapacity: PoolCapacity,
                    maxSize: PoolMaxSize
                );
    }

    public void CreateEnemy(Enemy prefab, Vector3 position, Transform path)
    {
        _position = position;
        _prefab = prefab;
        _path = path;

        _pool.Get();
    }

    private void Get(Enemy enemy)
    {
        _enemy = enemy;

        _enemy.Initialize(new WaypointsContainer(_path.Cast<Transform>()));
        _enemy.gameObject.SetActive(true);
    }

    private Enemy Create()
    {
        return Instantiate(_prefab, _position, Quaternion.identity);
    }
}