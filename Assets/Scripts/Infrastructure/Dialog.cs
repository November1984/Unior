using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Dialog : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _prefab;

    private SpriteRenderer _spriteRenderer;
    private Transform _newDialog;

    private void Start()
    {
        _newDialog = Instantiate(_prefab);
        _spriteRenderer = _newDialog.GetComponent<SpriteRenderer>();
    }

    public void Show(Vector3 position)
    {
        _newDialog.transform.position = position;
        _spriteRenderer.sprite = _sprite;

        _spriteRenderer.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _spriteRenderer.gameObject.SetActive(false);
    }
}