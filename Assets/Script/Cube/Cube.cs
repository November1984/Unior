using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(RandomCounter))]
public class Cube : MonoBehaviour, IPoolable
{
    [SerializeField] private float _minimumDestroyDelay = 1f;
    [SerializeField] private float _maximumDestroyDelay = 3f;

    public event Action<IPoolable> Destroyed;
    public event Action<Renderer> CollisionOccurred;

    private RandomCounter _randomCounter;
    private bool _isFirstContact;
    private bool _hasCounter;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        _randomCounter = GetComponent<RandomCounter>();

        Renderer.material.color = Color.blue;
        _isFirstContact = false;
    }

    private void OnDisable()
    {
        _randomCounter.Finished -= DestroyedNotify;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformFlag>(out PlatformFlag flag)
            & _isFirstContact == false)
        {
            _isFirstContact = true;

            CollisionOccurred?.Invoke(Renderer);

            _randomCounter.Finished += DestroyedNotify;

            _randomCounter.Launch(_minimumDestroyDelay, _maximumDestroyDelay);
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