using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(RandomCounter))]
public class Bomb : MonoBehaviour, IPoolable, IExplodeable
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private float _minimumDestroyDelay = 2f;
    [SerializeField] private float _maximumDestroyDelay = 5f;

    public event Action<IPoolable> Destroyed;

    private RandomCounter _randomCounter;

    public Renderer Renderer { get; private set; }
    public Transform Transform => transform;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        _randomCounter?.Launch(_minimumDestroyDelay, _maximumDestroyDelay);
    }

    private void OnDisable()
    {
        _randomCounter.Finished -= DestroyedNotify;
    }

    public void Init()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _randomCounter = GetComponent<RandomCounter>();

        _randomCounter.Finished += DestroyedNotify;
    }

    private void DestroyedNotify()
    {
        _exploder.Explode();
        Destroyed?.Invoke(this);
    }
}