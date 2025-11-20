using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IObstacle, IInteractable
{
    [SerializeField] private float _speed = 5f;

    private Coroutine _coroutine;
    private Vector3 _direction;
    private Collider2D _collider2D;
    private float _launchSpeed;

    public Collider2D Collider2D => _collider2D;

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

    public void SetParams(Vector3 position, Vector3 direction, float initialSpeed)
    {
        gameObject.transform.position = position;
        _direction = direction;
        _launchSpeed = _speed + initialSpeed;
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetPosition (Vector3 position)
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