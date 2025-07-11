using UnityEngine;

[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(GroundDetector))]

public class Unit : MonoBehaviour
{
    private UnitMovement _movement;
    private GroundDetector _groundContactCounter;
    private bool _isOnGround;
    private Health _health;
    private bool _canHeal;
    private UnitFight _fighter;
    private bool _canFight;

    public UnitMovement Movement => _movement;
    public bool IsOnGround => _isOnGround;
    public bool CanHeal => _canHeal;
    public float HitDistance => _canFight ? _fighter.HitDistance : 0;
    public bool IsHitting => _fighter.IsHitting;
    
    private void Awake()
    {
        _movement = GetComponent<UnitMovement>();
        _groundContactCounter = GetComponent<GroundDetector>();

        _canHeal = TryGetComponent<Health>(out _health);
        _canFight = TryGetComponent<UnitFight>(out _fighter);
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
    }

    public void Heal(float value)
    {
        _health.Increase(value);
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}