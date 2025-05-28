using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(MovementAnimator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _jumpSpeed = 6f;

    private Unit _unit;

    private void Awake()
    {
        _unit = new Unit(
                        GetComponent<Rigidbody2D>(),
                        GetComponent<GroundDetector>(),
                        GetComponent<MovementAnimator>()
        );
    }
}