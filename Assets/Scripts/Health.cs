using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float Total = 100;

    public event Action<float, float> Changed;

    public float CurrentValue { get; private set; }
    public float Max => Total;

    private void Awake()
    {
        CurrentValue = Total;
    }

    public void ChangeValue(float delta)
    {
        float newValue = CurrentValue + delta;

        CurrentValue = Mathf.Clamp(newValue, 0f, Total);

        Changed?.Invoke(CurrentValue, delta);
    }
}
