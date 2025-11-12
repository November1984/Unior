using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : ObjectPool<Obstacle>
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Terminator _terminator;
    
    private Coroutine _coroutine;

    protected override void OnStart()
    {
        _coroutine = StartCoroutine(Generate());
    }

    private void OnEnable()
    {
        _terminator.Terminated += Release;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _terminator.Terminated -= Release;
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            GetObj().SetPosition(transform.position);

            yield return wait;
        }
    }
}