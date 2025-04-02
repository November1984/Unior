using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Destroyed;

    private void OnEnable()
    {
        if (TryGetComponent<Renderer>(out Renderer renderer))
            renderer.material.color = Color.blue;
    }

    public void DestroyedNotify(Cube destroyedCube)
    {
        Destroyed?.Invoke(destroyedCube);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformFlag>(out PlatformFlag flag))
            if (TryPaint(Color.red))
                LaunchSelfDestroy();
    }

    private bool TryPaint(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer.material.color != color)
        {
            renderer.material.color = color;
            return true;
        }

        return false;
    }

    private void LaunchSelfDestroy()
    {
        if (TryGetComponent<Destroyer>(out Destroyer destroyer))
            destroyer.StartSelfDestroy();
    }
}