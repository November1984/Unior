using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.05f;

    private void Update()
    {
        transform.Translate(transform.forward * _speed);
    }
}
