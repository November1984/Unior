using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnsController : MonoBehaviour
{
    [SerializeField] private List<Bus> _busPrefabs;
    [SerializeField] private List<Unit> _unitPrefabs;
    [SerializeField] private List<BusSpawnPoint> _busSpawns;
    [SerializeField] private List<UnitSpawnPoint> _unitSpawns;
    [SerializeField] private float _repeateRate = 50f;

    private Coroutine _coroutine;
    private Dictionary<int, List<UnitSpawnPoint>> _unitSpawnsClassifyed;

    private void Awake()
    {
        SetBusPrefabs();
        SetUnitPrefabs();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Count());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private void SetBusPrefabs()
    {
        int index = 0;

        foreach (BusSpawnPoint spawn in _busSpawns)
        {
            spawn.SetPrefab(_busPrefabs[index]);
            index = ++index % _busPrefabs.Count;
        }
    }

    private void SetUnitPrefabs()
    {
        int index = 0;
        _unitSpawnsClassifyed = new Dictionary<int, List<UnitSpawnPoint>>();

        foreach (UnitSpawnPoint spawn in _unitSpawns)
        {
            spawn.SetPrefab(_unitPrefabs[index]);
            index = ++index % _busPrefabs.Count;

            if (_unitSpawnsClassifyed.ContainsKey(index))
            {
                _unitSpawnsClassifyed[index].Add(spawn);
            }
            else
            {
                _unitSpawnsClassifyed.Add(index, new List<UnitSpawnPoint>());
                _unitSpawnsClassifyed[index].Add(spawn);
            }
        }
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSecondsRealtime(_repeateRate);
        int busSpawnIndex;
        int unitSpawnIndex;

        while (true)
        {
            busSpawnIndex = GetRandomValue(_busSpawns.Count);
            Bus bus = _busSpawns[busSpawnIndex].LaunchBus();

            unitSpawnIndex = GetRandomValue(_unitSpawnsClassifyed[bus.Type].Count);
            _unitSpawnsClassifyed[bus.Type][unitSpawnIndex].SetAim(bus);

            yield return wait;
        }
    }

    private int GetRandomValue(int maxValue)
    {
        return Random.Range(0, maxValue);
    }
}
