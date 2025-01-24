using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(transform.up, _rotateSpeed);
    }
}
