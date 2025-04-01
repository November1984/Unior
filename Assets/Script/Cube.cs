using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public event Action<Cube> CubeRecolored;

    public void ColoredNotify(Cube recoloredObject)
    {
        CubeRecolored?.Invoke(recoloredObject);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}