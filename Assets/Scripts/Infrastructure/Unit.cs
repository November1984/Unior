using UnityEngine;

[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(GroundDetector))]

public class Unit : MonoBehaviour
{
    private UnitMovement _movement;
    private GroundDetector _groundContactCounter;
    private bool _isOnGround;
    private Starve _starve;
    private bool _canStarve;
    private Talker _talker;
    private bool _canTalk;

    public UnitMovement Movement => _movement;
    public bool IsOnGround => _isOnGround;
    public bool CanStarve => _canStarve;
    public float TalkDistance => _canTalk ? _talker.TalkDistance : 0;
    public bool IsTalking => _talker.IsTalking;

    private void Awake()
    {
        _movement = GetComponent<UnitMovement>();
        _groundContactCounter = GetComponent<GroundDetector>();

        _canStarve = TryGetComponent<Starve>(out _starve);
        _canTalk = TryGetComponent<Talker>(out _talker);
    }

    private void OnEnable()
    {
        _groundContactCounter.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _groundContactCounter.Grounded -= OnGrounded;
    }

    public void Talk()
    {
        _talker.ShowDialog();
    }

    public void Feed(float value)
    {
        _starve.Decrease(value);
    }

    private void OnGrounded(bool value)
    {
        _isOnGround = value;
    }
}