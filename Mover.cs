using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _placespoints;

    private Transform[] _places;
    private int _currentPlace = 0;

    private void Start()
    {
        _places = new Transform[_placespoints.childCount];

        for (int i = 0; i < _placespoints.childCount; i++)
            _places[i] = _placespoints.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        Vector3 _place = _places[_currentPlace].position;
        transform.position = Vector3.MoveTowards(transform.position, _place, _speed * Time.deltaTime);

        if (transform.position == _place)
            NextPlaceTakerLogic();
    }

    private void NextPlaceTakerLogic()
    {
        _currentPlace++;

        if (_currentPlace == _places.Length)
            _currentPlace = 0;

        Vector3 thisPointPosition = _places[_currentPlace].transform.position;
        transform.forward = thisPointPosition - transform.position;
    }
}