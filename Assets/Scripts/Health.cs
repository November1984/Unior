using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    const float TotalHealth = 100;

    public event Action<float, float> Changed;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => TotalHealth;

    private void Awake()
    {
        CurrentHealth = TotalHealth;
    }

    public void Change(float delta)
    {
        CurrentHealth += delta;

        if (CurrentHealth > TotalHealth)
            CurrentHealth = TotalHealth;
        else if (CurrentHealth < 0)
            CurrentHealth = 0;

        Changed?.Invoke(CurrentHealth, delta);
    }
}
