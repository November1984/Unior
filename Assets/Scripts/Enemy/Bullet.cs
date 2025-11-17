using System.Collections;
using UnityEngine;

public class Bullet : ObstacleUnit
{
    [SerializeField] private float _speed = 1f;

    private Coroutine _coroutine;
    public Vector3 _direction;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Fly());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void SetPosition(Vector3 position, Vector3 direction)
    {
        gameObject.transform.position = position;
        _direction = direction;

        gameObject.SetActive(true);
    }

    private IEnumerator Fly()
    {
        while (true)
        {
            yield return null;

            transform.position += _speed * _direction * Time.deltaTime;
        }
    }
}