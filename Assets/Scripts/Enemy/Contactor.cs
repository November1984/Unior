using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Contactor : MonoBehaviour
{
    public event Action<Player> PlayerSpotted;

    private bool _isPlayerSpoted = false;

    public bool IsPlayerSpoted => _isPlayerSpoted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            _isPlayerSpoted = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            PlayerSpotted?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _isPlayerSpoted = false;
            PlayerSpotted?.Invoke(player);
        }
    }
}