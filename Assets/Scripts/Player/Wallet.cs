using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public event Action<int> AmountChanged;

    private void Start()
    { _coins = 0; }

    public void AddCoin()
    { AmountChanged?.Invoke(++_coins); }
}
