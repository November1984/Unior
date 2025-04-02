using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private int MaxDestroyDelay = 5;

    private Coroutine _coroutine;

    public void StartSelfDestroy()
    {
        float delay = (float)GetRandomValue(MaxDestroyDelay);

        if (gameObject.TryGetComponent<Timer>(out Timer timer))
            timer.Launch(delay);

        _coroutine = StartCoroutine(Count(delay));
    }

    private void Destroy()
    {
        if (gameObject.TryGetComponent<Timer>(out Timer timer))
            timer.Stop();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (gameObject.TryGetComponent<Cube>(out Cube cube))
            cube.DestroyedNotify(cube);
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        Destroy();
    }

    private double GetRandomValue(int maxValue)
    {
        return Random.value * maxValue;
    }
}