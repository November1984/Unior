using UnityEngine;

public interface IDamageable
{
    public Healthbars.Health Health { get; }
    public Vector3 Position { get; }
}