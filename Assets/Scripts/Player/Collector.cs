using UnityEngine;

[RequireComponent(typeof(Healthbars.Health))]

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private Healthbars.Health _health;

    private void Awake()
    {
        _health = GetComponent <Healthbars.Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            coin.CollectedNotify();
            return;
        }

        if (collision.gameObject.TryGetComponent<MedKit>(out MedKit medKit))
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
        _health.ChangeValue(value);
    }
}