using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour, IPoolable, IDestroyable, IExplodeable
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private DestroyCounter _destroyer;

    public event Action<IDestroyable> Destroyed;
    public event Action<Renderer> CollisionOccurred;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        _destroyer?.StartSelfDestroyCounter();
    }

    private void OnDisable()
    {
        _destroyer.Finished -= DestroyedNotify;
    }

    public void Init()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _destroyer.Finished += DestroyedNotify;
    }

    private void DestroyedNotify()
    {
        // _exploder.Explode();
        Destroyed?.Invoke(this);
    }
}