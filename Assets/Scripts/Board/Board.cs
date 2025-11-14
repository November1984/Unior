using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Rigidbody2D))]
public class Board : MonoBehaviour
{
    [SerializeField] private ScoresCounter _scoresCounter;
    
    public event Action Crashed;

    private CollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
            case FirTree:
               EndGame();
                break;

            case Net:
                EndGame();
                break;

            case ScoreZone:
                _scoresCounter?.AddScore();
                break;
        }
    }
    
    public void Launch()
    {
        _rigidbody2D.simulated = true;
        transform.position = new Vector3();
    }
    
    private void EndGame()
    {
        Crashed?.Invoke();
        _scoresCounter?.ResetScores();
        _rigidbody2D.simulated = false;
    }
}
