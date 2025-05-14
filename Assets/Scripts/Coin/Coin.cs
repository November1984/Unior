using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            Collected?.Invoke(this);
    }
}
