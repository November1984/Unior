using System;
using UnityEngine;

public class InputReader : MonoBehaviour, IUnitMover
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    public event Action<float> UnitMoved;
    public event Action<float> UnitJumped;

    private void Update()
    {
        UnitMoved?.Invoke(Input.GetAxisRaw(Horisontal));
        UnitJumped?.Invoke(Input.GetAxisRaw(Vertical));
    }
}