using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _speed = 2f;

    public event Action<Unit> Disappeared;

    private Bus _aim;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _aim.transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bus>(out Bus bus))
        {
            if (bus == _aim)
            { Disappear(); }
        }
    }

    public void SetStartPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetAim(Bus aim)
    {
        _aim = aim;
        _aim.Stoped += Die;
    }

    public void Die(Bus aim)
    {
        if (gameObject.activeSelf)
            Instantiate(_effect, transform.position, transform.rotation);

        Disappear();
    }

    private void Disappear()
    {
        _aim.Stoped -= Die;
        DisappearedNotify(this);
    }

    private void DisappearedNotify(Unit crashedUnit)
    {
        Disappeared?.Invoke(crashedUnit);
    }
}
