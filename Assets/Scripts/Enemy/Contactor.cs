using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Contactor : MonoBehaviour
{
    [SerializeField] private float _closeDistance = 1f;
    public event Action<Player> PlayerSpotted;

    private bool _isPlayerSpoted = false;
    private Player _player;

    public bool IsPlayerSpoted => _isPlayerSpoted;
    public bool IsTooClose { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _player))
            _isPlayerSpoted = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _player))
        {
            PlayerSpotted?.Invoke(_player);
            IsTooClose = IsCloseDistance();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _player))
        {
            _isPlayerSpoted = false;
            PlayerSpotted?.Invoke(_player);
        }
    }

    private bool IsCloseDistance()
    {
        Vector3 offset = transform.position - _player.transform.position;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _closeDistance * _closeDistance;
    }
}