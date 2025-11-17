using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleUnit _prefab;
    [SerializeField] private ScoreZone _scoreZone;

    private void Start()
    {
        DisposeObj();
    }

    public Obstacle SetPosition(Vector3 position)
    {
        this.gameObject.transform.position = position;
        this.gameObject.SetActive(true);

        return this;
    }

    private void DisposeObj()
    {
        ObstacleUnit firstUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform);
        ObstacleUnit secondUnit = Instantiate(_prefab, transform.position, Quaternion.identity, transform);

        firstUnit.gameObject.SetActive(true);
        secondUnit.gameObject.SetActive(true);
        _scoreZone.gameObject.SetActive(true);

        float objHeight = firstUnit.Collider2D.bounds.size.y;
        float halfObjHeight = objHeight / 2;
        float halfScoreZoneHeight = _scoreZone.Height / 2;

        Vector3 deltaPosition = new (0, halfObjHeight + halfScoreZoneHeight, 0);
        
        firstUnit.gameObject.transform.position = transform.position - deltaPosition;
        _scoreZone.gameObject.transform.position = transform.position;
        secondUnit.gameObject.transform.position = transform.position + deltaPosition;
    }
}