using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Counter))]
[RequireComponent(typeof(Timer))]
public class Cube : MonoBehaviour, IPoolable<Cube>
{
    [SerializeField] private float _minimumDestroyDelay = 1f;
    [SerializeField] private float _maximumDestroyDelay = 3f;

    public event Action<Cube> Destroyed;
    public event Action<Renderer> CollisionOccurred;

    private Counter _counter;
    private Timer _timer;
    private bool _isFirstContact;

    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _counter = GetComponent<Counter>();
        _timer = GetComponent<Timer>();
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Renderer.material.color = Color.blue;
        _isFirstContact = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformFlag flag)
            & _isFirstContact == false)
        {
            _isFirstContact = true;

            CollisionOccurred?.Invoke(Renderer);

            _counter.Finished += DestroyedNotify;

            float delay = Random.Range(_minimumDestroyDelay, _maximumDestroyDelay);

            _counter.Launch(delay);
            _timer.Launch(delay);
        }
    }

    public void ResetPosition(float minSpawnCoordinate, float maxSpawnCoordinate, float spawnHeight)
    {
        float spawnPointX = Random.Range(minSpawnCoordinate, maxSpawnCoordinate);
        float spawnPointZ = Random.Range(minSpawnCoordinate, maxSpawnCoordinate);

        transform.SetPositionAndRotation(new Vector3(spawnPointX, spawnHeight, spawnPointZ), Quaternion.identity);
        Rigidbody.linearVelocity = Vector3.zero;
    }

    private void DestroyedNotify()
    {
        Destroyed?.Invoke(this);
        _counter.Finished -= DestroyedNotify;
    }
}