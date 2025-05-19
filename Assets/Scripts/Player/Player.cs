using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private Wallet _wallet;

    private Rigidbody2D _rigidBody;
    private GroundContactCounter _groundContactCounter;
    private bool _isOnGround;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public Transform Transform => transform;
    public bool IsOnGround => _isOnGround;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundContactCounter = GetComponent<GroundContactCounter>();
    }

    private void OnEnable()
    {_groundContactCounter.IsOnGround += Grounded;}

    private void OnDisable()
    {_groundContactCounter.IsOnGround -= Grounded;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            CollectCoin();
    }

    private void Grounded(bool value)
    { _isOnGround = value; }

    public void CollectCoin()
    { _wallet.AddCoin(); }
}
