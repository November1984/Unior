using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleUnit : MonoBehaviour
{
    public Collider2D Collider2D => _collider2D;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }
}