using UnityEngine;
using UnityEngine.Pool;

namespace Healthbars
{
    [RequireComponent(typeof(HealthView))]
    public class PopUpPointsSpawner : MonoBehaviour
    {
        [SerializeField] private PopUpPoint _prefab;

        private HealthView _healthView;
        private ObjectPool<PopUpPoint> _pool;
        private PopUpPoint _popUpPoint;
        private int _poolCapasity = 5;
        private int _poolMaxSize = 5;

        private void Awake()
        {
            _healthView = GetComponent<HealthView>();
            _pool = new ObjectPool<PopUpPoint>(
                createFunc: () => Create(),
                actionOnGet: (obj) => Get(obj),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _poolCapasity,
                maxSize: _poolMaxSize
            );
        }

        private void OnEnable()
        {
            _healthView.GetHealth().Changed += CreatePopUpPoint;
        }

        private void OnDisable()
        {
            _healthView.GetHealth().Changed -= CreatePopUpPoint;

            _pool.Dispose();
        }

        private void CreatePopUpPoint(float value, float delta)
        {
            _popUpPoint = _pool.Get();

            _popUpPoint.Launch(delta);
        }

        private void Get(PopUpPoint obj)
        {
            _popUpPoint = obj;
            _popUpPoint.transform.position = transform.position;

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

        private void Destroy(PopUpPoint obj)
        {
            obj.Disappeared -= Collect;

            Object.Destroy(obj);
        }
    }
}