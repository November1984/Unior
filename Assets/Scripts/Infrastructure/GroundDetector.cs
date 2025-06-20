using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _contactsCount = 0;

    public event Action<bool> Grounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _contactsCount++;
            Grounded?.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
            _contactsCount--;

        if (_contactsCount <= 0)
        {
            _contactsCount = 0;
            Grounded?.Invoke(false);
        }
    }
}
