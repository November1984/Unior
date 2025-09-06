using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Health : MonoBehaviour
{
    const float Total = 100;

    public event Action<float, float> Changed;

    public float Current { get; private set; }
    public float Max => Total;

    private void Awake()
    {
        Current = Total;
    }

    public void Change(float delta)
    {
        if (delta > 0)
            Increase(delta);
        else 
            Decrease(delta);
    }

    private void Increase(float delta)
    {
        Current += delta;

        if (Current > Total)
            Current = Total;

        Changed?.Invoke(Current, delta);
    }

    private void Decrease(float delta)
    {
        Current += delta;

        if (Current < 0)
            Current = 0;

        Changed?.Invoke(Current, delta);
    }
}
