using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Dissolver : MonoBehaviour
{
    private Coroutine _coroutine;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Launch(float delay)
    {
        _coroutine = StartCoroutine(Dessappear(delay));
    }

    private IEnumerator Dessappear(float delay)
    {
        const float TargetValue = 0;

        Color color = new();
        color.a = 1;
        _renderer.material.color = color;
        float alfa = color.a;
        float elapsedTime = 0;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(alfa, TargetValue, elapsedTime / delay);
            _renderer.material.color = color;

            yield return null;
        }
    }
}