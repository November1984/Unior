
using UnityEngine;

public interface IAutoAttacker
{
    public float Speed {get;}
    public Transform BasketBullets {get;}
    
    public Vector3 GetAttackDirection();
}