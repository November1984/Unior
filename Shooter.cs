using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _aim;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        Vector3 direction;
        var wait = new WaitForSeconds(_shootingDelay);

        while (enabled)
        {
            direction = (_aim.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.SetDirection(direction);
            bullet.SetVelocity(direction, _velocity);

            yield return wait;
        }
    }
}