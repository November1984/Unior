using UnityEngine;

[RequireComponent (typeof(Unit))]

public class InputReader : MonoBehaviour
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        _unit.MoveNotify((int) Input.GetAxisRaw(Horisontal));
        _unit.JumpedNotify((int) Input.GetAxisRaw(Vertical));
    }
}