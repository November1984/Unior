using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string Jump = nameof(Jump);

    public event Action<int> Moved;
    public event Action<int> Jumped;
    public event Action<bool> IsTalking;

    private void Update()
    {
        MoveNotify((int)Input.GetAxisRaw(Horizontal));
        JumpedNotify((int)Input.GetAxisRaw(Vertical));
        AttackimgNotify(Input.GetButton(Jump));
    }

    private void JumpedNotify(int value)
    {
        Jumped?.Invoke(value);
    }

    private void MoveNotify(int value)
    {
        Moved?.Invoke(value);
    }

    private void AttackimgNotify(bool value)
    {
        IsTalking?.Invoke(value);
    }
}