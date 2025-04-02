using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Destroyed;
    private Renderer _renderer;
    private bool _isFirstContact;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.blue;
        _isFirstContact = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformFlag>(out PlatformFlag flag)
            & _isFirstContact == false)
        {
            _isFirstContact = true;
            Paint(Color.red);
            LaunchSelfDestroy();
        }
    }

    public void DestroyedNotify(Cube destroyedCube)
    {
        Destroyed?.Invoke(destroyedCube);
    }

    private void Paint(Color color)
    {
        _renderer.material.color = color;
    }

    private void LaunchSelfDestroy()
    {
        if (TryGetComponent<Destroyer>(out Destroyer destroyer))
            destroyer.StartSelfDestroy();
    }
}