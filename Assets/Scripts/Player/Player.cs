using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour, IMoveAble
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private Wallet _wallet;

    private Rigidbody2D _rigidBody;
    private bool _isOnGround;
    
    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public Transform Transform => transform;
    public bool IsOnGround => _isOnGround;

    private void OnEnable() => _rigidBody = GetComponent<Rigidbody2D>();
    public void OnCollisionStay2D(Collision2D collision) => _isOnGround = true;
    public void OnCollisionExit2D(Collision2D collision) => _isOnGround = false;
    public void CollectCoin() => _wallet?.AddCoin();
}
