using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _placesPoints;
    [SerializeField] private float _closeDistance;

    private Transform[] _places;
    private int _currentPlace = 0;

    private void Start()
    {
        _places = new Transform[_placesPoints.childCount];

        for (int i = 0; i < _places.Length; i++)
            _places[i] = _placesPoints.GetChild(i);
    }

    public void Update()
    {
        Vector3 place = _places[_currentPlace].position;
        transform.position = Vector3.MoveTowards(transform.position, place, _speed * Time.deltaTime);

        Vector3 offset = transform.position - place;
        float sqrLength = offset.sqrMagnitude;

        if (sqrLength < _closeDistance * _closeDistance)
            SetNextPlace();
    }

    private void SetNextPlace()
    {
        _currentPlace = ++_currentPlace % _places.Length;

        Vector3 currentPosition = _places[_currentPlace].transform.position;
        transform.forward = currentPosition - transform.position;
    }
}