using System;
using UnityEngine;

public interface IPoolable<T> where T: MonoBehaviour
{
    public event Action<T> Destroyed;


    public virtual void Init() { }
}