using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour, IPoolable, IDestroyable
{
    [SerializeField] private DestroyCounter _destroyCounter;

    public event Action<IDestroyable> Destroyed;
    public event Action<Renderer> CollisionOccurred;

    private bool _isFirstContact;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        Renderer.material.color = Color.blue;
        _isFirstContact = false;
    }

    private void OnDisable()
    {
        _destroyCounter.Finished -= DestroyedNotify;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformFlag>(out PlatformFlag flag)
            & _isFirstContact == false)
        {
            _isFirstContact = true;

            CollisionOccurred?.Invoke(Renderer);

            _destroyCounter.Finished += DestroyedNotify;
            
            _destroyCounter.StartSelfDestroyCounter();
        }
    }

    public void Init()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void DestroyedNotify()
    {
        Destroyed?.Invoke(this);
    }
}