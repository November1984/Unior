using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreZone : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D => _boxCollider2D;
    [SerializeField] private float MinimumHeight { get; set; } = 4f;
    [SerializeField] private float MaximumHeight { get; set; } = 5f;
    public float Height { get; private set; }

    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        SetSize();
    }

    private void SetSize()
    {
        float width = 1f;
        Height = Random.Range(MinimumHeight, MaximumHeight) / 2f;

        _boxCollider2D.size = new Vector2(width, Height);
    }
}