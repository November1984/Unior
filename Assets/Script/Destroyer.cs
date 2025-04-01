using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private int MaxDestroyDelay = 5;

    private Coroutine _coroutine;
    private bool _canDestroy;
    private Cube _destroyedCube;

    private void OnEnable()
    {
        if (gameObject.TryGetComponent(out Cube cube))
            cube.CubeRecolored += StartDestroy;

        _canDestroy = false;
    }

    private void StartDestroy(Cube destroyedCube)
    {
        _destroyedCube = destroyedCube;
        _destroyedCube.CubeRecolored -= StartDestroy;

        float delay = (float)GetRandomValue(MaxDestroyDelay);
        Destroy(delay);

        if (destroyedCube.TryGetComponent<Timer>(out Timer timer))
            timer.Launch(delay);
    }

    private void Destroy(float delay = 0)
    {
        if (_canDestroy)
        {
            _destroyedCube.Destroy();

            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
        else
        {
            _coroutine = StartCoroutine(Count(delay));
        }
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        _canDestroy = true;
        Destroy();
    }

    private double GetRandomValue(int maxValue)
    {
        System.Random randomDelay = new();

        return randomDelay.NextDouble() * maxValue;
    }
}