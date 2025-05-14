using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    { _wallet.AmountChanged += ShowInfo; }

    private void OnDisable()
    { _wallet.AmountChanged -= ShowInfo; }

    private void ShowInfo(int amount)
    { _text.text = amount.ToString(); }
}