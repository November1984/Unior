using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = -150f;

    public Quaternion Rotation {get; private set;}

    private Transform _childTransform;

    private void Awake()
    {
        _childTransform = transform.GetChild(1);
    }

    private void Update()
    {
        Vector3 directionRotate = Time.deltaTime * _rotationSpeed * Vector3.forward;
        _childTransform.Rotate(directionRotate);
        Rotation = _childTransform.rotation;
    }
}