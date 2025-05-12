using UnityEngine;

public class Player : MonoBehaviour, IAnimateAble
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private Wallet _wallet;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;
    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;

    public void OnCollisionStay2D(Collision2D collision) => _isGrounded = true;
    public void OnCollisionExit2D(Collision2D collision) => _isGrounded = false;
    public void CollectCoin() => _wallet?.AddCoin();
}
