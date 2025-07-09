using UnityEngine;

[RequireComponent(typeof(Health))]

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _hitForce = 5;

    private Health _health;

    public float HitDistance => 0.5f;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Damage(float value)
    {
        _health.Decrease(value);
    }
}