using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BusSpawnPoint : MonoBehaviour
{
    [SerializeField] private int _poolCapasity = 15;
    [SerializeField] private int _poolMaxSize = 15;
    [SerializeField] private RouteGenerator _routeGenerator;

    private ObjectPool<Bus> _pool;
    private Bus _prefab;

    private void Start()
    {
        _pool = new ObjectPool<Bus>(
            createFunc: () => Create(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => DestroyBus(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    public void SetPrefab(Bus prefab)
    {
        _prefab = prefab;
    }

    public Bus LaunchBus()
    {
       return _pool.Get();
    }

    private void ActionOnGet(Bus bus)
    {
        List<Vector3> waypoints = _routeGenerator.GetRoute(transform.position);
        bus.SetRoute(waypoints);
        bus.gameObject.SetActive(true);
    }

    private Bus Create()
    {
        var bus = Instantiate(_prefab);
        bus.FinishedRoute += Collect;

        return bus;
    }

     private void DestroyBus(Bus bus)
    {
        bus.FinishedRoute -= Collect;
        Destroy(bus);
    }

   private void Collect(Bus bus)
    {
        _pool.Release(bus);
    }
}