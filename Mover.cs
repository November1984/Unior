using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _placesPoints;

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
        Vector3 _place = _places[_currentPlace].position;
        transform.position = Vector3.MoveTowards(transform.position, _place, _speed * Time.deltaTime);

        if (transform.position == _place)
            TakeNextPlace();
    }

    private void TakeNextPlace()
    {
        _currentPlace = ++_currentPlace % _places.Length;

        Vector3 thisPointPosition = _places[_currentPlace].transform.position;
        transform.forward = thisPointPosition - transform.position;
    }
}