using System;

interface IHealthBar
{
    public event Action<float> Changed;

    public float Width { get; }
}