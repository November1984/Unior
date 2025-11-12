using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Tapped;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Tapped?.Invoke();
    }
}