using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private Wallet _wallet;

    private Rigidbody2D _rigidBody;

    public float RunSpeed => _runSpeed;
    public float JumpSpeed => _jumpSpeed;
    public Rigidbody2D Rigidbody => _rigidBody;
    public Transform Transform => transform;

    private void Awake()
    { _rigidBody = GetComponent<Rigidbody2D>(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            CollectCoin();
    }

    public void CollectCoin()
    { _wallet.AddCoin(); }
}
