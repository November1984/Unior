using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class PopUpPointsSpawner : MonoBehaviour
{
    [SerializeField] private PopUpPoint _prefab;
    [SerializeField] private TextHealthBar _textHealthBar;

    private ObjectPool<PopUpPoint> _pool;
    private int _poolCapasity = 5;
    private int _poolMaxSize = 5;
    private PopUpPoint _popUpPoint;

    private void Awake()
    {
        _pool = new ObjectPool<PopUpPoint>(
            createFunc: () => Create(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => ActionOnDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize
        );
    }

    private void OnEnable()
    {
        _textHealthBar.Changed += CreatePopUpPoint;
    }

    private void OnDisable()
    {
        _textHealthBar.Changed -= CreatePopUpPoint;

        _pool.Dispose();
    }

    private void CreatePopUpPoint(float value)
    {
        _popUpPoint = _pool.Get();

        _popUpPoint.Launch(value);
    }

    private void ActionOnGet(PopUpPoint obj)
    {
        _popUpPoint = obj;
        _popUpPoint.transform.position = transform.position + _textHealthBar.Width /2 * Vector3.right;

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