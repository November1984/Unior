using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = -150f;
    [SerializeField] private Unit _prefab;
    [SerializeField] private float _repeateRate = 2f;
    [SerializeField] private int _poolCapasity = 15;
    [SerializeField] private int _poolMaxSize = 15;

    private ObjectPool<Unit> _pool;
    private Vector3 _direction;
    private Quaternion _rotation;

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

    private void Update()
    {
        _direction = Time.deltaTime * _rotationSpeed * Vector3.forward;
        transform.Rotate(_direction);
        _rotation = transform.rotation;
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
        unit.transform.SetPositionAndRotation(transform.position, _rotation);
        unit.Rigidbody.AddForce(unit.transform.up * unit.Speed);
    }
}
