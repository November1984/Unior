using UnityEngine;

[RequireComponent(typeof(PlayerStateMachineFactory))]
[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private UnitAnimator _unitAnimator;
    private Movement _movement;
    private GroundDetector _groundContactCounter;
    private bool _isOnGround;

    public Movement Movement => _movement;
    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _groundContactCounter = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }

    public void Initialize()
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _stateMachine = GetComponent<PlayerStateMachineFactory>().Create(this, _unitAnimator);
    }
}