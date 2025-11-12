using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Terminator : MonoBehaviour
{
    public event Action<Obstacle> Terminated;

    private BoxCollider2D _collider;

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
         if (collision.TryGetComponent(out Obstacle obj))
            Terminated?.Invoke(obj);
    }
}