using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public event Action<int> AmountChanged;

    public int Coins => _coins;

    private void Start()
    {
        _coins = 0;
    }

    public void AddCoin()
    {
        _coins++;
        
        AmountChanged?.Invoke(_coins);
    }
}
