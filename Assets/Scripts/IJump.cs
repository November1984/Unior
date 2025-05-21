using System;

public interface IJump
{
    public event Action<float> UnitJumped;
}