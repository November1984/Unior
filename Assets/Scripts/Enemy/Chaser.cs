using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Chaser : MonoBehaviour
{
    [SerializeField, Min(0)] private float _closeDistance = 0.9f;
    [SerializeField, Min(0)] private float _runSpeed = 1f;

    public bool IsUnitApproached { get; private set; } = false;
    public IDamageable ApproachedUnit { get; private set; }
    public Transform Unit { get; set; }
    public float CloseDistance => _closeDistance;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = _closeDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable component))
        {
            IsUnitApproached = true;
            ApproachedUnit = component;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable component))
        {
            IsUnitApproached = false;
            ApproachedUnit = component;
        }
    }

    public int MoveTo(Vector3 chasedUnitPosition)
    {
        Unit.position = Vector3.MoveTowards(Unit.position, chasedUnitPosition, _runSpeed * Time.deltaTime);

        return Math.Sign(chasedUnitPosition.x - Unit.position.x);
    }
}