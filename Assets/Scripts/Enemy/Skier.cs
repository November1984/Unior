using UnityEngine;

public class Skier : ObstacleUnit, IInteractable, IAttacker
{
    public Vector3 GetAttackDirection()
    {
        return Vector3.left;
    }
}