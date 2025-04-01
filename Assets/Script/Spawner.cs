using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    private const float SpawnHeight = 6;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeateRate = 1f;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;
    [SerializeField] private float _minSpawnCoordinate = -3;
    [SerializeField] private float _maxSpawnCoordinate = 3;

    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeateRate);
    }

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    public void Collect(GameObject obj)
    {
        _pool.Release(obj);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = new Vector3(
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate),
            SpawnHeight,
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate)
            );
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.SetActive(true);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}