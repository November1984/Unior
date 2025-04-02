using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    private const float SpawnHeight = 6;

    [SerializeField] private Cube _prefab;
    [SerializeField] private float _repeateRate = 1f;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;
    [SerializeField] private float _minSpawnCoordinate = -3;
    [SerializeField] private float _maxSpawnCoordinate = 3;

    private ObjectPool<Cube> _pool;

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeateRate);
    }

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Create(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    public void Collect(Cube obj)
    {
        _pool.Release(obj);
    }

    private Cube Create()
    {
        Cube cube = Instantiate(_prefab);
        cube.Destroyed += Collect;

        return cube;
    }

    private void ActionOnGet(Cube obj)
    {
        obj.transform.position = new Vector3(
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate),
            SpawnHeight,
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate)
            );
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.gameObject.SetActive(true);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}