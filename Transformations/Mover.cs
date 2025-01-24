using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.05f;

    private void Update()
    {
        transform.Translate(transform.forward * _moveSpeed);
    }
}
