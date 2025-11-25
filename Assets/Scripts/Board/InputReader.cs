using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Jump = KeyCode.Space;
    private const KeyCode Fire = KeyCode.Mouse0;
    
    public event Action Tapped;
    public event Action Attacking;

    public bool Ride { get; set; } = false;

    private void Update()
    {
        if (Ride)
        {
            if (Input.GetKeyDown(Jump))
                Tapped?.Invoke();

            if (Input.GetKeyDown(Fire))
                Attacking?.Invoke();
        }
    }
}