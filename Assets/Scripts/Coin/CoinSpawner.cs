using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
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
        for (int i = 0; i < _spawnPoints.transform.childCount; i++)
        {
            Transform point = _spawnPoints.transform.GetChild(i);
            Coin coin = _pool.Get();
            coin.transform.position = point.position;
        }
    }

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    public void Collect(Coin obj)
    {
        _pool.Release(obj);
    }

    private Coin Create()
    {
        Coin coin = Instantiate(_prefab);
        coin.Collected += Collect;

        return coin;
    }

    private void CoinDestroy(Coin obj)
    {
        obj.Collected -= Collect;

        Destroy(obj);
    }
}
