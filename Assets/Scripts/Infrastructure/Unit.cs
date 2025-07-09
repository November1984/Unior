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
    private Fighter _fighter;
    private bool _canFight;

    public UnitMovement Movement => _movement;
    public bool IsOnGround => _isOnGround;
    public bool CanHeal => _canHeal;
    public float HitDistance
    {
        get
        {
            if (_canFight)
                return _fighter.HitDistance;

            return 0;
        }
    }

    private void Awake()
    {
        _movement = GetComponent<UnitMovement>();
        _groundContactCounter = GetComponent<GroundDetector>();

        _canHeal = TryGetComponent<Health>(out _health);

        _canFight = TryGetComponent<Fighter>(out _fighter);
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