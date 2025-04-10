using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using System.Collections;

public class BusSpawner : MonoBehaviour
{
    [SerializeField] private Bus _prefab;
    [SerializeField] private float _repeateRate = 30f;
    [SerializeField] private int _poolCapasity = 15;
    [SerializeField] private int _poolMaxSize = 15;
    [SerializeField] private List<SpawnPoint> _spawns;

    private ObjectPool<Bus> _pool;
    private Coroutine _coroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Bus>(
            createFunc: () => Create(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => DestroyUnit(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Count(_repeateRate));
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
        _pool.Dispose();
    }

    private Bus Create()
    {
        var bus = Instantiate(_prefab);
        bus.FinishedRoute += Collect;

        return bus;
    }

    private void Collect(Bus bus)
    {
        _pool.Release(bus);
    }

    private void DestroyUnit(Bus bus)
    {
        bus.FinishedRoute -= Collect;
        Destroy(bus);
    }

    private void ActionOnGet(Bus bus)
    {
        bus.gameObject.SetActive(true);
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            _pool.Get();

            yield return wait;
        }
    }
}
