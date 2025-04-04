using System;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public event Action Exploded;

    public void ExplodedNotify()
    {
        Exploded?.Invoke();
    }
}