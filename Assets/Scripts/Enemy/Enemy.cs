using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1f;

    public float RunSpeed => _runSpeed;
    public Transform Transform => transform;
}
