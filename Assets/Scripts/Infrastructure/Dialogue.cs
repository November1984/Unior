using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Dialogue
{
    private SpriteRenderer _spriteRenderer;
    private GameObject _object;

    public Dialogue()
    {
        _spriteRenderer = _object.AddComponent<SpriteRenderer>();
    }

    public void Show(Vector3 position, Sprite sprite)
    {
        _object.transform.position = position;
        _spriteRenderer.sprite = sprite;

        _spriteRenderer.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _spriteRenderer.gameObject.SetActive(false);
    }
}