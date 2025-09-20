using UnityEngine;

[RequireComponent(typeof(Contactor))]
public class Chaser : MonoBehaviour
{
    private Contactor _contactor;

    public Transform PlayerPosition { get; private set; }
    public bool IsPlayerSpotted { get; private set; }
    public bool IsClosePosition { get; private set; }

    private void Awake()
    {
        _contactor = GetComponent<Contactor>();
    }

    private void OnEnable()
    {
        _contactor.PlayerSpotted += PlayerSpottedNotify;
    }

    private void OnDisable()
    {
        _contactor.PlayerSpotted -= PlayerSpottedNotify;
    }

    private void PlayerSpottedNotify(Transform playerPosition)
    {
        IsPlayerSpotted = _contactor.IsPlayerSpoted;
        PlayerPosition = playerPosition;
        IsClosePosition = _contactor.IsTooClose;
    }
}