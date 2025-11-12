using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class BoardMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 5;
    [SerializeField] private float _speed = 7;
    [SerializeField] private float _rotationSpeed = 2;
    [SerializeField] private float _minRotationZ = 0;
    [SerializeField] private float _maxRotationZ = 70;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;
    private InputReader _inputReader;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Tapped += Move;
    }

    private void OnDisable()
    {
        _inputReader.Tapped -= Move;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Move()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _rigidbody2D.linearVelocity = new Vector3(_speed, _tapForce, 0);
        transform.rotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _coroutine = StartCoroutine(Return());
    }

    private IEnumerator Return()
    {
        float targetPosition;

        while (transform.rotation.eulerAngles.z > _minRotationZ)
        {
            targetPosition = Mathf.Lerp(transform.rotation.eulerAngles.z, _minRotationZ, _rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, targetPosition);

            yield return null;
        }

        StopCoroutine(_coroutine);

        _coroutine = null;
    }
}
