using System;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _closeDistance = 0.9f;
    [SerializeField] private float _runSpeed = 1f;

    public bool IsApproached { get; private set; }

    public int MoveTo(Vector3 chasedUnitPosition)
    {
        if (CheckCloseDistance(chasedUnitPosition))
        {
            IsApproached = true;
            return 0;
        }

        IsApproached = false;
        transform.position = Vector3.MoveTowards(transform.position, chasedUnitPosition, _runSpeed * Time.deltaTime);

        return Math.Sign(chasedUnitPosition.x - transform.position.x);
    }

    private bool CheckCloseDistance(Vector3 chasedUnitPosition)
    {
        Vector3 offset = transform.position - chasedUnitPosition;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _closeDistance * _closeDistance;
    }
}