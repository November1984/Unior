using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable, IDestroyable
{
    [SerializeField] protected T _prefab;
    [SerializeField] private int _poolCapasity = 35;
    [SerializeField] private int _poolMaxSize = 50;

    public event Action<IPoolable> ObjCollected;
    private ObjectPool<T> _pool;

    protected virtual void Start() { }

    protected virtual void ActionOnGet(IPoolable obj) { }

    protected void GetObj()
    {
        _pool.Get();
    }

    protected virtual T Create()
    {
        T obj = Instantiate(_prefab);

        obj.Init();
        obj.Transform.gameObject.SetActive(true);

        obj.Destroyed += Collect;

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

    private void Collect(IDestroyable obj)
    {
        _pool.Release((T)obj);
        ObjCollected?.Invoke(obj);
    }

    private void DestroyT(T obj)
    {
        obj.Destroyed -= Collect;

        Destroy(obj);
    }
}