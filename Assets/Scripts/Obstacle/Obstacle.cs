using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ScoreZone _scoreZone;

    private IObstacle _upperUnit;
    private IObstacle _bottomUnit;
    private bool _isInitialized = false;

    private void OnEnable()
    {
        if (_isInitialized == false)
            DisposeObj();
    }

    public void Locate(Vector3 position)
    {
        gameObject.transform.position = position;

        _upperUnit.SetActive(true);
        _bottomUnit.SetActive(true);
    }

    private void DisposeObj()
    {
        _upperUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform).GetComponent<IObstacle>();
        _bottomUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform).GetComponent<IObstacle>();

        _upperUnit.SetActive(true);
        _bottomUnit.SetActive(true);
        _scoreZone.gameObject.SetActive(true);

        float objHeight = _upperUnit.Collider2D.bounds.size.y;
        float halfObjHeight = objHeight / 2;
        float halfScoreZoneHeight = _scoreZone.Height / 2;

        Vector3 deltaPosition = new(0, halfObjHeight + halfScoreZoneHeight, 0);

        _upperUnit.SetPosition(transform.position - deltaPosition);
        _scoreZone.gameObject.transform.position = transform.position;
        _bottomUnit.SetPosition(transform.position + deltaPosition);

        _isInitialized = true;
    }
}