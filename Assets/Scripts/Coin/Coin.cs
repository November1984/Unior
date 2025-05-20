using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    public void CollectedNotify()
    {
        Collected?.Invoke(this);
    }
}
