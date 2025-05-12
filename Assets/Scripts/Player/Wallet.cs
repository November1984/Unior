using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int> AmountChanged;
    
    private int _coins = 0;

    private void Start() => _coins = 0;

    public void AddCoin()
    {
        _coins++;
        AmountChanged?.Invoke(_coins);
    }
}
