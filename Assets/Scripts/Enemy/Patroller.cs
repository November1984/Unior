using System;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _closeDistance = 0.5f;
    [SerializeField] private float _runSpeed = 2f;
    [SerializeField] private bool _isActive = true;

    public event Action<bool> Reached;

    public int MoveTo(Vector3 waypoint)
    {
        if (_isActive == false)
            return 0;

        if (CheckCloseDistance(waypoint) == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint, _runSpeed * Time.deltaTime);

            Reached?.Invoke(false);

            return Math.Sign(waypoint.x - transform.position.x);
        }

        Reached?.Invoke(true);

        return 0;
    }

    private bool CheckCloseDistance(Vector3 waypoint)
    {
        Vector3 offset = transform.position - waypoint;
        float sqrLength = offset.sqrMagnitude;

        return sqrLength < _closeDistance * _closeDistance;
    }
}