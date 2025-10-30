using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Counter))]
[RequireComponent(typeof(Dissolver))]
public class Bomb : MonoBehaviour, IPoolable, IExplodeable
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private float _minimumDestroyDelay = 2f;
    [SerializeField] private float _maximumDestroyDelay = 5f;

    public event Action<IPoolable> Destroyed;

    private Counter _counter;
    private Dissolver _dissolver;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        float delay = UnityEngine.Random.Range(_minimumDestroyDelay, _maximumDestroyDelay);

        _counter.Launch(delay);
        _dissolver.Launch(delay);
    }

    private void OnDisable()
    {
        _counter.Finished -= DestroyedNotify;
    }

    public void Init()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _counter = GetComponent<Counter>();
        _dissolver = GetComponent<Dissolver>();

        _counter.Finished += DestroyedNotify;
    }

    private void DestroyedNotify()
    {
        _exploder.Explode();
        Destroyed?.Invoke(this);
    }
}