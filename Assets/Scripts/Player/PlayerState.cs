using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private GroundContactCounter _groundContactCounter;
    private bool _isOnGround;

    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _groundContactCounter = GetComponent<GroundContactCounter>();
    }

    private void OnEnable()
    { _groundContactCounter.IsOnGround += Grounded; }

    private void OnDisable()
    { _groundContactCounter.IsOnGround -= Grounded; }

    private void Grounded(bool value)
    { _isOnGround = value; }
}