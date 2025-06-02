using System;

public interface IUnitMover
{
    abstract public event Action<float> UnitMoved;
    abstract public event Action<float> UnitJumped;
}