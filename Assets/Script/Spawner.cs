using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : ISpawner where T : MonoBehaviour, IPoolable
{
    [SerializeField] protected T _prefab;
    [SerializeField] private int _poolCapasity = 10;
    [SerializeField] private int _poolMaxSize = 10;

    public event Action<IPoolable> ObjCollected;
    private ObjectPool<T> _pool;

    protected virtual void Start() { }

    protected virtual void ActionOnGet(IPoolable obj) { }

    protected T GetObj()
    {
        ActiveCount = _pool.CountActive;

        return _pool.Get();
    }

    protected virtual T Create()
    {
        T obj = Instantiate(_prefab);

        obj.Destroyed += Collect;
        CreatedCount++;

        return obj;
    }

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Create(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => DestroyT(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    private void Collect(IPoolable obj)
    {
        ActiveCount = _pool.CountActive;
        _pool.Release((T)obj);
        ObjCollected?.Invoke(obj);
    }

    private void DestroyT(T obj)
    {
        obj.Destroyed -= Collect;
        ActiveCount = _pool.CountActive;
        
        if (obj != null)
            Destroy(obj.gameObject);
    }
}