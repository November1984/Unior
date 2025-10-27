using System;
using UnityEngine;

public interface IPoolable
{
    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }

    public abstract void Init();
}