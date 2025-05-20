using UnityEngine;

[RequireComponent(typeof(UnitMover))]

public class InputReader : MonoBehaviour
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    private UnitMover _unitMover;

    private void Awake()
    {
        _unitMover = GetComponent<UnitMover>();
    }

    private void FixedUpdate()
    {
        _unitMover.Move(Input.GetAxisRaw(Horisontal));
        _unitMover.Jump(Input.GetAxisRaw(Vertical));
    }
}