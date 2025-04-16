using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    public void SetDirection(Vector3 direction)
    {
        transform.up = direction;
    }

    public void SetVelocity(Vector3 direction, float velocity)
    {
        GetComponent<Rigidbody>().linearVelocity = direction * velocity;
    }
}