using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public abstract class CollectibleItem<T> : MonoBehaviour where T : MonoBehaviour
{
    public event Action<T> Collected;

    public void CollectedNotify()
    {
        Collected?.Invoke(this as T);
    }
}