
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FirTree : ObstacleUnit, IInteractable
{
    private Collider2D _collider2D;

    public override Collider2D Collider => _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public override void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public override void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}