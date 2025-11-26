using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CollisionHandler : MonoBehaviour
{
    private Collider2D _collider2D;

    public event Action<IInteractable> CollisionDetected;
    
    public Collider2D Collider => _collider2D;

    private void OnValidate()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }
}