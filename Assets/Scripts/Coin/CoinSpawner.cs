using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
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

    private void OnEnable() => SubscribePrefabs();
    private void OnDisable() => UnsubscribePrefabs();
    private void OnDestroy() => _pool.Dispose();

    public void Collect(Coin obj) => _pool.Release(obj);

    private Coin Create()
    {
        Coin coin = Instantiate(_coins[0]);
        coin.Collected += Collect;

        return coin;
    }

    private void CoinDestroy(Coin obj)
    {
        obj.Collected -= Collect;

        Destroy(obj);
    }

    private void SubscribePrefabs()
    {
        foreach (Coin coin in _coins)
            coin.Collected += Collect;
    }

    private void UnsubscribePrefabs()
    {
        foreach (Coin coin in _coins)
            coin.Collected -= Collect;
    }
}
