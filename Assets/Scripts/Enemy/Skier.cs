using UnityEngine;

public class Skier : ObstacleUnit, IInteractable, IAutoAttacker
{
    [SerializeField] private BasketBullets _basketBullets;
    
    public float Speed => 0;
    public Transform BasketBullets => _basketBullets.transform;

    public Vector3 GetAttackDirection()
    {
        return Vector3.left;
    }
}