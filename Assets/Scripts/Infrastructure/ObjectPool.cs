using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool;
    private List<T> _createdObjs;

    private void Awake()
    {
        _pool = new();
        _createdObjs = new();
    }

    public T GetObj(Transform parent = null)
    {
        T obj;

        if (_pool.Count == 0)
        {
            obj = Instantiate(_prefab, parent);

            _createdObjs.Add(obj);
        }
        else
        {
            obj = _pool.Dequeue();
        }

        obj.gameObject.SetActive(true);
        Subscribe(obj);

        return obj;
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

    protected virtual void Subscribe(T obj)
    {}
}