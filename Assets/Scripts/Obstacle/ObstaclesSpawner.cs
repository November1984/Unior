using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool _obstaclePool;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private ObstacleTerminator _terminator;
    [SerializeField] private float _upperBound = 4f;
    [SerializeField] private float _lowerBound = -2f;

    private Coroutine _coroutine;

    public void Launch()
    {
        _coroutine = StartCoroutine(Generate());
    }

    public void Stop()
    {
        StopCoroutine(_coroutine);
        _obstaclePool.Reset();
    }

    private void OnEnable()
    {
        _terminator.Terminated += _obstaclePool.PutObject;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _terminator.Terminated -= _obstaclePool.PutObject;
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (enabled)
        {
            yield return wait;

            _obstaclePool.GetObj().Locate(GetSpawnPoint());
        }
    }

    private Vector3 GetSpawnPoint()
    {
        float yPosition = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = transform.position + yPosition * Vector3.up;

        return spawnPoint;
    }
}