using System;

public interface IDestroyable : IPoolable
{
    public event Action<IDestroyable> Destroyed;
}