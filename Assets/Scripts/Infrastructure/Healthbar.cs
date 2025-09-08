using System;
using UnityEngine;

public abstract class Healthbar : MonoBehaviour, IHealthBar
{
    [SerializeField] protected Health Health;

    public event Action<float, float> Changed;

    public float Width { get; protected set; }

    private void Awake()
    {
        Width = 0;
    }

    private void Start()
    {
        Change(Health.CurrentValue, 0);
    }

    protected void OnEnable()
    {
        Health.Changed += Change;
    }

    protected virtual void OnDisable()
    {
        Health.Changed -= Change;
    }

    protected virtual void Change(float value, float delta)
    { 
        ChangeNotify(value, delta);
    }

    protected void ChangeNotify(float value, float delta)
    {
        Changed?.Invoke(value, delta);
    }
}