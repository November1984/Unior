using System;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class MovementInput : MonoBehaviour
{
    public event Action<float> Moving;
    public event Action<float> Jumping;

    private readonly string _horisontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private void Update()
    {
        MovingNotify(Input.GetAxisRaw(_horisontal));
        JumpingNotify(Input.GetAxisRaw(_vertical));
    }

    private void MovingNotify(float value) =>
        Moving?.Invoke(value);

    private void JumpingNotify(float value) =>
        Jumping?.Invoke(value);
}
