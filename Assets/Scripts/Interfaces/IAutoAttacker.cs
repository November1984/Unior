
using UnityEngine;

public interface IAutoAttacker
{
    public float Speed { get; }
    public Transform BasketBullets { get; }
    public bool CanAttack { get; }
    public Vector3 Position { get; }

    public Vector3 GetAttackDirection();
}