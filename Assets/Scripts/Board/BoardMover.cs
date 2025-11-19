using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(IMoveable))]
public class BoardMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 5;
    [SerializeField] private float _speed = 7;
    [SerializeField] private float _rotationSpeed = 2;
    [SerializeField] private float _minRotationZ = -35;
    [SerializeField] private float _maxRotationZ = 35;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;
    private InputReader _inputReader;
    private IMoveable _unit;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _unit = GetComponent<IMoveable>();
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
        _unit.Speed = _speed;

        _coroutine = StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        float targetAngle;
        float targetWeight;

        while (transform.rotation.eulerAngles.z > _minRotationZ)
        {
            targetAngle = Mathf.Lerp(transform.rotation.z, Quaternion.Euler(0,0,_minRotationZ).z, _rotationSpeed * Time.deltaTime);
            targetWeight = Mathf.Lerp(transform.rotation.w, Quaternion.Euler(0,0,_minRotationZ).w, _rotationSpeed * Time.deltaTime);
            transform.rotation = new Quaternion (0, 0, targetAngle, targetWeight);

            yield return null;
        }

        StopCoroutine(_coroutine);

        _coroutine = null;
    }
}
