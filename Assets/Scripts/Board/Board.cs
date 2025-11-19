using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Rigidbody2D))]
public class Board : MonoBehaviour, IMoveable, IAttacker
{
    [SerializeField] private ScoresCounter _scoresCounter;
    [SerializeField] private BasketBullets _boardersBullets;

    public event Action Crashed;

    private CollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody2D;
    
    public float Speed {get; set;}
    public Transform BasketBullets => _boardersBullets.transform;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D.simulated = false;
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;
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
        _rigidbody2D.linearVelocity = new (0,0);
        transform.position = new Vector3();
    }
    
    public Vector3 GetAttackDirection()
    {
        return gameObject.transform.right;
    }
    
    private void EndGame()
    {
        Crashed?.Invoke();
        _scoresCounter?.ResetScores();
        _rigidbody2D.simulated = false;
    }
}
