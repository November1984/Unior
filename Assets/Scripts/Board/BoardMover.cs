using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoardMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 4;
    [SerializeField] private float _speed = 7;
    [SerializeField] private float _rotationSpeed = 2;
    [SerializeField] private float _minRotationZ = -35;
    [SerializeField] private float _maxRotationZ = 35;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;

    public float Speed => _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Move()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _rigidbody2D.linearVelocity = new Vector3(_speed, _tapForce, 0);
        transform.rotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _coroutine = StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        Quaternion targetRotation;

        while (transform.rotation.eulerAngles.z > _minRotationZ)
        {
            targetRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _minRotationZ), _rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;

            yield return null;
        }

        StopCoroutine(_coroutine);

        _coroutine = null;
    }
}
