using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T: MonoBehaviour
{
    [SerializeField] private T _prefab;
    
    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart(){}

    public T GetObj()
    {
        if (_pool.Count == 0)
        {
            T obj = Instantiate(_prefab);
            obj.gameObject.SetActive(true);
            
            return obj;
        }

        return _pool.Dequeue();
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}