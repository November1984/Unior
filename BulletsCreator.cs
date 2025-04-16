using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsCreator : MonoBehaviour
{
   [SerializeField] private float _velocity;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _aim;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(ShootingWorker());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator ShootingWorker()
    {
        Vector3 direction;
        var wait = new WaitForSeconds(_shootingDelay);

        while (true)
        {
            direction = (_aim.position - transform.position).normalized;
            var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _velocity;

            yield return wait;
        }
    }
}