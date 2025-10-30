using System;
using UnityEngine;

public interface IPoolable
{
    public event Action<IPoolable> Destroyed;

    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }

    public abstract void Init();

    public void Reset()
    {
        Transform.SetPositionAndRotation(new Vector3(), Quaternion.identity);
        Rigidbody.linearVelocity = Vector3.zero;
    }
}