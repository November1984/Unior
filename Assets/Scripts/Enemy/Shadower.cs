using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(MoveGenerator))]

public class Shadower : MonoBehaviour
{
    private MoveGenerator _moveGenerator;

    private void Awake()
    { _moveGenerator = GetComponent<MoveGenerator>(); }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerState player))
            _moveGenerator.SetAim(player.transform);
    }
}
