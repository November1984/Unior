using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : ObstacleUnit
{
    [SerializeField] private float _speed = 5f;

    private Coroutine _coroutine;
    private Vector3 _direction;

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
        _speed += initialSpeed;
        
        gameObject.SetActive(true);
    }

    private IEnumerator Fly()
    {
        while (true)
        {
            yield return null;

            transform.position += _speed * _direction * Time.deltaTime;
            transform.rotation = quaternion.identity;
        }
    }
}