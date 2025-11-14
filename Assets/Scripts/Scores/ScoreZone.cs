using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreZone : MonoBehaviour, IInteractable
{
    [SerializeField] private float _zoneSize = 6f;

    public BoxCollider2D BoxCollider2D => _boxCollider2D;
    public float Height { get; private set; }

    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        SetZoneSize();
    }

    private void SetZoneSize()
    {
        float width = 1f;
        Height = _zoneSize / 2f;

        _boxCollider2D.size = new Vector2(width, Height);
    }
}