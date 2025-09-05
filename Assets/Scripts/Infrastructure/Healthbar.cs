using System;
using UnityEngine;

public abstract class Healthbar : MonoBehaviour, IHealthBar
{
    [SerializeField] protected Health _health;

    public event Action<float> Changed;

    public float Width { get; protected set; }

    private void Awake()
    {
        Width = 0;
    }

    private void Start()
    {
        Change(_health.CurrentHealth);
    }

    protected void OnEnable()
    {
        _health.Changed += Change;
    }

    protected void OnDisable()
    {
        _health.Changed -= Change;
    }

    protected virtual void Change(float value)
    { 
        ChangeNotify(value);
    }

    protected void ChangeNotify(float value)
    {
        Changed?.Invoke(value);
    }
}