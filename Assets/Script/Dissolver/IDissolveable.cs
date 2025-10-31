using System;

public interface IDissolveable
{
    public event Action<float> DissolveEnabled;
}