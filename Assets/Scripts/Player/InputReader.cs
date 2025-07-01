using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    public event Action<int> Moved;
    public event Action<int> Jumped;

    private void Update()
    {
        MoveNotify((int)Input.GetAxisRaw(Horisontal));
        JumpedNotify((int)Input.GetAxisRaw(Vertical));
    }

    private void JumpedNotify(int value)
    {
        Jumped?.Invoke(value);
    }

    private void MoveNotify(int value)
    {
        Moved?.Invoke(value);
    }
}