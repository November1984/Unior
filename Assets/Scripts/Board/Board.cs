using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Board : MonoBehaviour
{
    private CollisionHandler _collisionHandler;
    private event Action GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCrash;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCrash;
    }

    private void OnCrash(IInteractable interactable)
    {
        if (interactable is FirTree)
            GameOver?.Invoke();
        else if (true)
            return;
    }
}
