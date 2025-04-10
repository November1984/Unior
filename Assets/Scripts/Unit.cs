using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _speed = 100f;

    public event Action<Unit> Crashed;

    public float Speed { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody = rigidbody2D;
    }

    private void OnEnable()
    {
        Speed = _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<UnitFlag>(out UnitFlag flag))
            CrashNotify(this);
    }

    public void SetDirection(Vector3 position, Quaternion rotation)
    {
        Rigidbody.transform.position = position;
        transform.rotation = rotation;
        Rigidbody.AddForce(transform.up * Speed);
    }

    public void Explode()
    {
        if (gameObject.activeSelf)
            Instantiate(_effect, transform.position, transform.rotation);
    }

    private void CrashNotify(Unit crashedUnit)
    {
        Crashed?.Invoke(crashedUnit);
    }
}
