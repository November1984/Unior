using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Healthbar))]
public class PopUpPointsSpawner : MonoBehaviour
{
    [SerializeField] private PopUpPoint _prefab;

    private Healthbar _HealthBar;
    private ObjectPool<PopUpPoint> _pool;
    private PopUpPoint _popUpPoint;
    private int _poolCapasity = 5;
    private int _poolMaxSize = 5;

    private void Awake()
    {
        _HealthBar = GetComponent<Healthbar>();
        _pool = new ObjectPool<PopUpPoint>(
            createFunc: () => Create(),
            actionOnGet: (obj) => Get(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => ActionOnDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void OnEnable()
    {
        _HealthBar.Changed += CreatePopUpPoint;
    }

    private void OnDisable()
    {
        _HealthBar.Changed -= CreatePopUpPoint;

        _pool.Dispose();
    }

    private void CreatePopUpPoint(float value, float delta)
    {
        _popUpPoint = _pool.Get();

        _popUpPoint.Launch(delta);
    }

    private void Get(PopUpPoint obj)
    {
        float healthbarCenter = _HealthBar.Width / 2;
        
        _popUpPoint = obj;
        _popUpPoint.transform.position = transform.position + healthbarCenter * Vector3.right;

        _popUpPoint.gameObject.SetActive(true);
    }

    private PopUpPoint Create()
    {
        PopUpPoint item = Instantiate(_prefab, transform);
        item.Disappeared += Collect;

        return item;
    }

    private void Collect(PopUpPoint obj)
    {
        _pool.Release(obj);
    }

    private void ActionOnDestroy(PopUpPoint obj)
    {
        obj.Disappeared -= Collect;

        Destroy(obj);
    }
}