using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private IDamageable _player;

    private void Awake()
    {
        _player = GetComponent<IDamageable>();
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
        _player.Health?.ChangeValue(value);
    }
}