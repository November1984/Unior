using System;

public interface IMove
{
    public event Action<float> UnitMoved;
}