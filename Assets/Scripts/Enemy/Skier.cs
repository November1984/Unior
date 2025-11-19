using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(CollisionHandler))]
public class Skier : MonoBehaviour, IObstacle, IInteractable, IAutoAttacker, IDamageable
{
    [SerializeField] private BasketBullets _basketBullets;

    public event Action Defeated;
    public event Action Placed;
    private CollisionHandler _collisionHandler;
    private Collider2D _collider2D;

    public Collider2D Collider2D => _collider2D;
    public float Speed => 0;
    public Transform BasketBullets => _basketBullets.transform;
    public bool CanAttack { get; private set; }

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;
        CanAttack = true;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;
    }

    public Vector3 GetAttackDirection()
    {
        return Vector3.left;
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetPosition (Vector3 position)
    {
        transform.position = position;
        Placed?.Invoke();
    }

    private void OnCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            CanAttack = false;
            Defeated?.Invoke();
        }
    }
}