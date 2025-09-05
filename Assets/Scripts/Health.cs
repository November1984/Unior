using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    const float TotalHealth = 100;

    public event Action<float> Changed;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float FullHealth => TotalHealth;

    private void Awake()
    {
        _currentHealth = TotalHealth;
    }

    public void Change(float value)
    {
        _currentHealth += value;

        if (_currentHealth > TotalHealth)
            _currentHealth = TotalHealth;
        else if (_currentHealth < 0)
            _currentHealth = 0;

        Changed?.Invoke(value);
    }
}
