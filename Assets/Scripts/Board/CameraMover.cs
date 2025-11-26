using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _ofset = 6f;
    [SerializeField] private Board _board;

    private float _position;

    private void LateUpdate()
    {
        _position = _board.transform.position.x + _ofset;
        transform.position = _position * Vector3.right + Vector3.back;
    }
}
