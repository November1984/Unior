using System;
using UnityEngine;

public interface IPoolable
{
    public event Action<IPoolable> Destroyed;

    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }

    public void Init(){}
    public void Reset(){}
}