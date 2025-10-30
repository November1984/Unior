using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Counter))]
[RequireComponent(typeof(Timer))]
public class Cube : MonoBehaviour, IPoolable
{
    [SerializeField] private float _minimumDestroyDelay = 1f;
    [SerializeField] private float _maximumDestroyDelay = 3f;

    public event Action<IPoolable> Destroyed;
    public event Action<Renderer> CollisionOccurred;

    private Counter _counter;
    private Timer _timer;
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
        _counter.Finished -= DestroyedNotify;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformFlag flag)
            & _isFirstContact == false)
        {
            _isFirstContact = true;

            CollisionOccurred?.Invoke(Renderer);

            _counter.Finished += DestroyedNotify;

            float delay = UnityEngine.Random.Range(_minimumDestroyDelay, _maximumDestroyDelay);

            _counter.Launch(delay);
            _timer.Launch(delay);
        }
    }

    public void Init()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _counter = GetComponent<Counter>();
        _timer = GetComponent<Timer>();
    }

    private void DestroyedNotify()
    {
        Destroyed?.Invoke(this);
    }
}