using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ParametersViewer : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private ISpawner _spawner;

    private TextMeshProUGUI _textMeshPro;
    private Coroutine _coroutine;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(ShowData());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator ShowData()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _textMeshPro.text = $"Создано: {_spawner?.CreatedCount};\n" + 
                                $"Выведено на сцену: {_spawner?.SpawnedCount};\n" +
                                $"Активно: {_spawner?.ActiveCount};";
            yield return wait;
        }
    }
}