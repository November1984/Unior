using System;
using UnityEngine;

public class GroundContactCounter : MonoBehaviour
{
    private const string Platform = nameof(Platform);

    public event Action<bool> IsOnGround;

    private int _contactsCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(Platform))
        {
            _contactsCount++;
            IsOnGroundNotify(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(Platform))
            _contactsCount--;

        if (_contactsCount <= 0)
        {
            _contactsCount = 0;
            IsOnGroundNotify(false);
        }
    }

    private void IsOnGroundNotify(bool value)
    {IsOnGround?.Invoke(value);}
}
