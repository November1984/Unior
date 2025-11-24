
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FirTree : MonoBehaviour, IObstacle, IInteractable
{
    private Collider2D _collider2D;

    public Collider2D Collider => _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetPosition (Vector3 position)
    {
        gameObject.transform.position = position;
    }
}