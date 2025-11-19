
using System;
using UnityEngine;

public interface IAutoAttacker
{
    public event Action Placed;
    
    public float Speed { get; }
    public Transform BasketBullets { get; }
    public bool CanAttack { get; }

    public Vector3 GetAttackDirection();
}