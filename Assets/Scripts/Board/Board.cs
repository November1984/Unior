using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Rigidbody2D))]
public class Board : MonoBehaviour
{
    [SerializeField] private ScoresCounter _scoresCounter;
    [SerializeField] private InputReader _inputReader;

    public event Action Crashed;

    private CollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody2D;
    private Shooter _attack;
    private bool _canAttack;
    private BoardMover _boardMover;
    private bool _canMoving;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _canAttack = TryGetComponent(out _attack);
        _canMoving = TryGetComponent(out _boardMover);
    }

    private void Start()
    {
        _rigidbody2D.simulated = false;
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;

        if (_canAttack)
            _inputReader.Attacking += Shoot;

        if (_canMoving)
        _inputReader.Tapped += Move;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;
        
        if (_canAttack)
            _inputReader.Attacking -= Shoot;

        if (_canMoving)
            _inputReader.Tapped -= Move;
    }

    private void OnCollision(IInteractable interactable)
    {
        switch (interactable)
        {
            case ScoreZone:
                _scoresCounter?.AddScore();
                break;

            default:
                EndGame();
                break;
        }
    }

    public void Launch()
    {
        _rigidbody2D.simulated = true;
        _rigidbody2D.linearVelocity = new(0, 0);
        transform.position = new Vector3();

        _scoresCounter?.ResetScores();
    }

    public Vector3 GetAttackDirection()
    {
        return gameObject.transform.right;
    }

    private void Shoot()
    {
        const string BulletLayerName = "BoarderBullets";

        if (_canAttack)
            _attack.Shoot(gameObject.transform.right,
                          _collisionHandler.Collider,
                          BulletLayerName,
                          _boardMover.Speed
                          );
    }

    private void Move()
    {
        _boardMover.Move();
    }

    private void EndGame()
    {
        Crashed?.Invoke();
        _rigidbody2D.simulated = false;
    }
}
