using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Contactor : MonoBehaviour
{
    public event Action<Player> PlayerSpotted;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            PlayerSpotted?.Invoke(player);
    }
}