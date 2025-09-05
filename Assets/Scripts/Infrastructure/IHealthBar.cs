using System;

interface IHealthBar
{
    public event Action<float, float> Changed;

    public float Width { get; }
}