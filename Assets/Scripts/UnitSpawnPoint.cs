using UnityEngine;
using UnityEngine.Pool;

public class UnitSpawnPoint : MonoBehaviour
{
    [SerializeField] private int _poolCapasity = 15;
    [SerializeField] private int _poolMaxSize = 15;

    private ObjectPool<Unit> _pool;
    private Unit _prefab;
    private Bus _aim;

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

    private void OnDestroy()
    {
        _pool.Dispose();
    }

    public void SetPrefab(Unit prefab)
    {
        _prefab = prefab;
    }

    public void SetAim(Bus aim)
    {
        _aim = aim;
        _pool.Get();
    }

    private void DestroyUnit(Unit unit)
    {
        unit.Crashed -= Collect;
        Destroy(unit);
    }

    private void ActionOnGet(Unit unit)
    {
        unit.SetStartPosition(transform.position);
        unit.SetAim(_aim);
        unit.gameObject.SetActive(true);
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
}
