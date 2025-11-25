using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleUnit : MonoBehaviour
{
    public abstract Collider2D Collider {get;}

    public abstract void SetActive(bool value);
    public abstract void SetPosition(Vector3 position);
}