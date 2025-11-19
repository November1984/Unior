using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ScoreZone _scoreZone;

    private void Start()
    {
        DisposeObj();
    }

    public Obstacle SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
        gameObject.SetActive(true);

        return this;
    }

    private void DisposeObj()
    {
        IObstacle firstUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform).GetComponent<IObstacle>();
        IObstacle secondUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform).GetComponent<IObstacle>();
        
        firstUnit.SetActive(true);
        secondUnit.SetActive(true);
        _scoreZone.gameObject.SetActive(true);

        float objHeight = firstUnit.Collider2D.bounds.size.y;
        float halfObjHeight = objHeight / 2;
        float halfScoreZoneHeight = _scoreZone.Height / 2;

        Vector3 deltaPosition = new(0, halfObjHeight + halfScoreZoneHeight, 0);

        firstUnit.SetPosition(transform.position - deltaPosition);
        _scoreZone.gameObject.transform.position = transform.position;
        secondUnit.SetPosition(transform.position + deltaPosition);
    }
}