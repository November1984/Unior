using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Tapped;
    public event Action Attacking;

    public bool Ride { get; set; } = false;

    private void Update()
    {
        if (Ride)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Tapped?.Invoke();

            if (Input.GetKeyDown(KeyCode.Mouse0))
                Attacking?.Invoke();
        }
    }
}