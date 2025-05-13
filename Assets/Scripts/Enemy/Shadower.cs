using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
[RequireComponent (typeof(MoveGenerator))]
public class Shadower : MonoBehaviour
{
    private MoveGenerator _moveGenerator;
    
    private void OnEnable()
    {
        _moveGenerator = GetComponent<MoveGenerator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _moveGenerator.GetAim(player.transform);
    }
}
