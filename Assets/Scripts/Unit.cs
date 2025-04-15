using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _speed = 2f;

    public event Action<Unit> Crashed;

    private Bus _aim;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody = rigidbody2D;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _aim.transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bus>(out Bus bus))
            if (bus == _aim)
            {
                _aim.FinishedRoute -= Explode;
                CrashNotify(this);
            }
    }

    public void SetStartPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetAim(Bus aim)
    {
        _aim = aim;
        _aim.FinishedRoute += Explode;
    }

    public void SetDirection(Vector3 position, Quaternion rotation)
    {
        Rigidbody.transform.position = position;
        transform.rotation = rotation;
        Rigidbody.AddForce(transform.up * _speed);
    }

    public void Explode(Bus aim)
    {
        if (gameObject.activeSelf)
            Instantiate(_effect, transform.position, transform.rotation);

        _aim.FinishedRoute -= Explode;
        CrashNotify(this);
    }

    private void CrashNotify(Unit crashedUnit)
    {
        Crashed?.Invoke(crashedUnit);
    }
}
