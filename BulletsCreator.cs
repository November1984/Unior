using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsCreator : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _aim;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Shooter());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shooter()
    {
        Vector3 direction;
        var wait = new WaitForSeconds(_shootingDelay);

        while (enabled)
        {
            direction = (_aim.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _velocity;

            yield return wait;
        }
    }
}