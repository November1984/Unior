using System;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField, Range(-180f, 180f)] private float _rotateAngle;

    private void Update()
    {
        transform.position = Vector3.zero + Quaternion.Euler(0, _rotateAngle, 0) * new Vector3(0,0, - Vector3.Distance(transform.position, Vector3.zero));
        transform.LookAt(Vector3.zero);
    }
}
