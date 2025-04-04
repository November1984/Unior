using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Unit _prefab;
    [SerializeField] private float _repeateRate = 2f;
    [SerializeField] private int _poolCapasity = 15;
    [SerializeField] private int _poolMaxSize = 15;
    [SerializeField] private List<SpawnPoint> _spowns;

    private ObjectPool<Unit> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Unit>(
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
        InvokeRepeating(nameof(GetUnit), 0.0f, _repeateRate);
    }

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    private Unit Create()
    {
        var unit = Instantiate(_prefab);
        unit.Crashed += Collect;
        
        return unit;
    }

    private void Collect(Unit unit)
    {
        _pool.Release(unit);
    }

    private void DestroyUnit(Unit unit)
    {
        unit.Crashed -= Collect;
        Destroy(unit);
    }

    private void GetUnit()
    {
        _pool.Get();
    }

    private void ActionOnGet(Unit unit)
    {
        unit.gameObject.SetActive(true);

        SpawnPoint spawnPoint = GetRandomSpawnPoint();
        
        unit.Rigidbody.transform.position = spawnPoint.transform.position;
        unit.transform.rotation = spawnPoint.Rotation;
        unit.Rigidbody.AddForce(unit.transform.up * unit.Speed);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        int index = UnityEngine.Random.Range(0, _spowns.Count);

        return _spowns[index];
    }
}
