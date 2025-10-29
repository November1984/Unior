using System.Collections;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    private Coroutine _coroutine;

    public void Launch(Renderer renderer)
    {
        _coroutine = StartCoroutine(Dessappear(renderer));
    }

    private IEnumerator Dessappear(Renderer renderer)
    {
        float alfa = renderer.material.color.a;

        while (alfa > 0)
        {
            yield return null;
        }
    }
}