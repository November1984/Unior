using UnityEngine;

[RequireComponent(typeof(Player))]

public class MovementController : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private readonly string _horisontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private void Update()
    {
        _mover.Move(Input.GetAxisRaw(_horisontal));
        _mover.Jump(Input.GetAxisRaw(_vertical));
    }
}
