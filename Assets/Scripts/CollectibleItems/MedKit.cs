using UnityEngine;
public class MedKit : CollectibleItem<MedKit>
{
    [SerializeField] private float _valuation = 20f;
    public float HealAmount => _valuation;
}