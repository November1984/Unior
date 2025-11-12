using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private List<ObstacleUnit> _obstacles;
    [SerializeField] private ScoreZone _scoreZone;

    private ObstacleUnit _obstacle;
    private int _obstaclesCount;

    private void OnEnable()
    {
        _obstacle = GetObj();
        _obstaclesCount = GetObjCount();
    }

    private void Start()
    {
        DisposeObj(_obstacle);
    }

    public Obstacle SetPosition(Vector3 position)
    {
        this.gameObject.transform.position = position;

        return this;
    }

    private ObstacleUnit GetObj()
    {
        int obstacleType = 0;

        if (_obstacles.Count > 1)
            obstacleType = Random.Range(0, _obstacles.Count);

        return _obstacles[obstacleType];
    }

    private int GetObjCount()
    {
        const int MinimumObjCount = 0;
        const int MaximumObjCount = 2;

        return Random.Range(MinimumObjCount, MaximumObjCount + 1);
    }

    private void DisposeObj(ObstacleUnit obj)
    {
        ObstacleUnit firstUnit = Instantiate(obj, transform.position, Quaternion.identity, transform);
        ObstacleUnit secondUnit = null;

        firstUnit.gameObject.SetActive(true);
        _scoreZone.gameObject.SetActive(true);

        float objHeight = firstUnit.Collider2D.bounds.size.y;
        float halfObjHeight = objHeight / 2;
        float halfScoreZoneHeight = _scoreZone.Height / 2;

        Vector3 firstUnitPosition = transform.position - (halfObjHeight + halfScoreZoneHeight) * Vector3.up + Vector3.forward;
        firstUnit.gameObject.transform.position = firstUnitPosition; 
        _scoreZone.gameObject.transform.position = transform.position;

        if (_obstaclesCount > 1)
        {
            Vector3 secondtUnitPosition = transform.position + (halfObjHeight + halfScoreZoneHeight) * Vector3.up + Vector3.forward;
            secondUnit = Instantiate(obj, transform.position, Quaternion.identity, transform);
            secondUnit.gameObject.transform.position = secondtUnitPosition;
        }

        secondUnit?.gameObject.SetActive(true);
    }
}