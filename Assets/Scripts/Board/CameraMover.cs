using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float _ofset = 6f;
    [SerializeField] Board _board;

    private float _position;

    private void Update()
    {
        _position = _board.transform.position.x + _ofset;
        transform.position = _position * Vector3.right + Vector3.back;
    }
}
