using UnityEngine;

public abstract class HealthView : MonoBehaviour, IHealthBar
{
    [SerializeField] protected Health Health;

    public float Width { get; protected set; }

    private void Awake()
    {
        Width = 0;
    }

    private void Start()
    {
        Change(Health.CurrentValue, 0);
    }

    public Health GetHealth()
    {
        return Health;
    }

    protected void OnEnable()
    {
        Health.Changed += Change;
    }

    protected virtual void OnDisable()
    {
        Health.Changed -= Change;
    }

    protected abstract void Change(float value, float delta);
}