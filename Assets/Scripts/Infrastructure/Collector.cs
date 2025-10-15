using Healthbars;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            coin.CollectedNotify();
            return;
        }

        if (collision.gameObject.TryGetComponent<MedKit>(out MedKit medKit) )
        {
            CollectMedkit(medKit.HealAmount);
            medKit.CollectedNotify();
        }
    }

    private void CollectCoin()
    {
        _wallet.AddCoin();
    }

    private void CollectMedkit(float value)
    {
        _health.Increase(value);
    }
}