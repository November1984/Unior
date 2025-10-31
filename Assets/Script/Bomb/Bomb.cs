using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Counter))]
[RequireComponent(typeof(Dissolver))]
public class Bomb : MonoBehaviour, IPoolable, IExplodeable
{
    [SerializeField] private float _minimumDestroyDelay = 2f;
    [SerializeField] private float _maximumDestroyDelay = 5f;

    public event Action<IPoolable> Destroyed;
    public event Action Exploded;

    private Counter _counter;
    private Dissolver _dissolver;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _counter = GetComponent<Counter>();
        _dissolver = GetComponent<Dissolver>();
    }

    private void OnEnable()
    {
        float delay = Random.Range(_minimumDestroyDelay, _maximumDestroyDelay);

        _counter.Launch(delay);
        _counter.Finished += DestroyedNotify;
        _dissolver.Launch(delay);
    }

    private void DestroyedNotify()
    {
        Exploded?.Invoke();
        Destroyed?.Invoke(this);
        _counter.Finished -= DestroyedNotify;
    }
}