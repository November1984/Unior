using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollisionHandler))]
public class Skier : MonoBehaviour, IObstacle, IInteractable, IDamageable
{
    [SerializeField] private float _fireDelay = 2f;

    public event Action Defeated;
    public event Action Placed;
    private CollisionHandler _collisionHandler;
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private AttackTimer _autoAttacker;
    private bool _canAutoAttack;
    private Shooter _shooter;
    private bool _canAttack;

    public Collider2D Collider => _collider2D;
    public float Speed => 0;
    public bool CanAttack { get; private set; }

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _canAutoAttack = TryGetComponent(out _autoAttacker);
        _canAttack = TryGetComponent(out _shooter);
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;

        if (_canAutoAttack)
        {
            _autoAttacker.Shot += Shoot;
            _autoAttacker.Launch(_fireDelay);
        }
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;

        if (_canAutoAttack)
            _autoAttacker.Shot -= Shoot;
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
        _rigidbody2D.simulated = value;
        CanAttack = true;

        Placed?.Invoke();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void OnCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            Defeat();
        }
    }

    private void Shoot()
    {
        const string BulletLayerName = "SkiersBullets";

        if (_canAttack)
            _shooter.Shoot(Vector3.left,
                          Collider,
                          BulletLayerName
                          );
    }

    private void Defeat()
    {
        CanAttack = false;
        _rigidbody2D.simulated = false;

        _autoAttacker.StopShoot();
        Defeated?.Invoke();
    }
}