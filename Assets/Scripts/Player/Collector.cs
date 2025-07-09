using UnityEngine;

[RequireComponent(typeof(Unit))]

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            coin.CollectedNotify();
            return;
        }

        if (collision.gameObject.TryGetComponent<MedKit>(out MedKit medKit) &&
            _unit.CanHeal)
        {
            _unit.Heal(medKit.HealAmount);
            medKit.CollectedNotify();
        }
    }

    private void CollectCoin()
    {
        _wallet.AddCoin();
    }
}