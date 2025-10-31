using System;

public interface IExplodeable : IPoolable
{
    public event Action Exploded;
}