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

    public void Increase(float delta)
    {
        CurrentValue += delta;

        if (CurrentValue > Total)
            CurrentValue = Total;

        Changed?.Invoke(CurrentValue, delta);
    }

    public void Decrease(float delta)
    {
        CurrentValue += delta;

        if (CurrentValue < 0)
            CurrentValue = 0;

        Changed?.Invoke(CurrentValue, delta);
    }
}
