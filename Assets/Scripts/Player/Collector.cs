using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            coin.CollectedNotify();
        }
    }

    public void CollectCoin()
    {
        _wallet.AddCoin();
    }
}