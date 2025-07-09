using UnityEngine;
using UnityEngine.Pool;

public abstract class CollectibleItemSpawner<T> : MonoBehaviour where T : CollectibleItem<T>
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Create(),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => CoinDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void OnEnable()
    {
        if (_spawnPoints.transform.childCount > 0)
            for (int i = 0; i < _spawnPoints.transform.childCount; i++)
            {
                Transform point = _spawnPoints.transform.GetChild(i);
                T item = _pool.Get();
                item.transform.position = point.position;
            }
        else
        {
            Transform point = _spawnPoints.transform;
            T item = _pool.Get();
            item.transform.position = point.position;
        }
    }

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    public void Collect(T obj)
    {
        _pool.Release(obj);
    }

    private T Create()
    {
        T item = Instantiate(_prefab);
        item.Collected += Collect;

        return item;
    }

    private void CoinDestroy(T obj)
    {
        obj.Collected -= Collect;

        Destroy(obj);
    }
}
