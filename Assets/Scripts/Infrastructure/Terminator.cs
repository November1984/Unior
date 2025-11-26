using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Terminator<T> : MonoBehaviour where T: MonoBehaviour
{
    private BoxCollider2D _collider;

    public event Action<T> Terminated;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.TryGetComponent(out T obj))
            Terminated?.Invoke(obj);
    }
}