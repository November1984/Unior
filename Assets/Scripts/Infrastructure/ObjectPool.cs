using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T: MonoBehaviour
{
    [SerializeField] private T _prefab;
    
    private Queue<T> _pool;
    private List<T> _createdObjs;

    private void Awake()
    {
        _pool = new();
        _createdObjs = new();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart(){}

    public T GetObj(Transform parent = null)
    {
        if (_pool.Count == 0)
        {
            T obj = Instantiate(_prefab, parent);

            _createdObjs.Add(obj);
            
            return obj;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (T obj in _createdObjs)
            Destroy(obj.gameObject);
        
        _createdObjs.Clear();
        _pool.Clear();
    }
}