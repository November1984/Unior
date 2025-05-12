using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    public void Move(int value) => _animator.SetInteger("Direction", value);

    public void Idle()
    {
        _animator.SetBool("IsOnGround", true);
        _animator.SetBool("IsJumped", false);
    }

    public void Jump()
    {
        _animator.SetBool("IsJumped", true);
        _animator.SetBool("IsLanding", false);
        _animator.SetBool("IsOnGround", false);
    }

    public void Landing()
    {
        _animator.SetBool("IsLanding", true);
        _animator.SetBool("IsJumped", false);

    }
}
