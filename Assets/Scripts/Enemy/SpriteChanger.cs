using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(IDamageable))]
public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _staySprite;
    [SerializeField] private Sprite _laySprite;

    private SpriteRenderer _spriteRenderer;
    private IDamageable _unit;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _spriteRenderer.sprite = _staySprite;
        _unit.Defeated += Change;
    }

    private void OnDisable()
    {
        _unit.Defeated -= Change;
    }

    private void Change()
    {
        _spriteRenderer.sprite = _laySprite;
    }
}