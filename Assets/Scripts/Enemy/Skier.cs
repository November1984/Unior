using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),
                  typeof(CollisionHandler),
                  typeof(Collider2D))]
public class Skier : ObstacleUnit, IInteractable, IDamageable
{
    [SerializeField] private float _fireDelay = 2f;

    private CollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody2D;
    private AttackTimer _attackTimer;
    private bool _canAutoAttack;
    private Shooter _shooter;
    private bool _canAttack;
    private Collider2D _collider2D;

    public event Action Defeated;
    public event Action Placed;

    public override Collider2D Collider => _collider2D;
    public float Speed => 0;
    public bool CanAttack { get; private set; }

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _canAutoAttack = TryGetComponent(out _attackTimer);
        _canAttack = TryGetComponent(out _shooter);
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;

        if (_canAutoAttack)
        {
            _attackTimer.Triggered += Shoot;
            _attackTimer.Launch(_fireDelay);
        }
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;

        if (_canAutoAttack)
            _attackTimer.Triggered -= Shoot;
    }

    public override void SetActive(bool value)
    {
        gameObject.SetActive(value);
        _rigidbody2D.simulated = value;
        CanAttack = true;

        Placed?.Invoke();
    }

    public override void SetPosition(Vector3 position)
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

        _attackTimer.StopShoot();
        Defeated?.Invoke();
    }
}