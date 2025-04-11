using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnsController : MonoBehaviour
{
    [SerializeField] private List<Bus> _prefabs;
    [SerializeField] private List<SpawnPoint> _spawns;
    [SerializeField] private float _repeateRate = 30f;

    private Coroutine _coroutine;

    private void Awake()
    {
        int index = 0;
        foreach (SpawnPoint spawn in _spawns)
        {
            spawn.SetPrefab(_prefabs[index]);
            index = ++index % _prefabs.Count;
        }
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Count());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSecondsRealtime(_repeateRate);

        while (true)
        {
            int spawnIndex = GetRandomValue(_spawns.Count);
            _spawns[spawnIndex].LaunchBus();
            
            yield return wait;
        }
    }

    private int GetRandomValue(int maxValue)
    {
        return Random.Range(0, maxValue);
    }
}
