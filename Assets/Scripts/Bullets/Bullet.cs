using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : ObstacleUnit, IInteractable
{
    [SerializeField] private float _speed = 5f;

    public event Action<Bullet> Collided;

    private Coroutine _coroutine;
    private Vector3 _direction;
    private float _launchSpeed;
    private Collider2D _collider2D;

    public override Collider2D Collider => _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Fly());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable item))
             if (item is ScoreZone == false)
                Collided?.Invoke(this);
    }

    public void SetParams(Vector3 position, Vector3 direction, float initialSpeed)
    {
        gameObject.transform.position = position;
        _direction = direction;
        _launchSpeed = _speed + initialSpeed;
    }

    public override void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public override void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }

    private IEnumerator Fly()
    {
        while (true)
        {
            yield return null;

            transform.position += _launchSpeed * _direction * Time.deltaTime;
            transform.rotation = quaternion.identity;
        }
    }
}