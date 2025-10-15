using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string Jump = nameof(Jump);

    public event Action<int> Moved;
    public event Action<int> Jumped;
    public event Action<bool> IsAttacked;
    public event Action<bool> IsVampiring;

    private void Update()
    {
        MoveNotify((int)Input.GetAxisRaw(Horizontal));
        JumpedNotify((int)Input.GetAxisRaw(Vertical));
        AttackingNotify(Input.GetButton(Jump));
        VampireNotify(Input.GetKeyDown(KeyCode.V));
    }

    private void JumpedNotify(int value)
    {
        Jumped?.Invoke(value);
    }

    private void MoveNotify(int value)
    {
        Moved?.Invoke(value);
    }

    private void AttackingNotify(bool value)
    {
        IsAttacked?.Invoke(value);
    }

    private void VampireNotify(bool value)
    {
        IsVampiring?.Invoke(value);
    }
}