using UnityEngine;

[RequireComponent(typeof(Animator))]

public class UnitAnimator : MonoBehaviour
{
    const string JumpForward = nameof(JumpForward);
    const string MoveForward = nameof(MoveForward);
    const string MoveBackward = nameof(MoveBackward);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.Play(JumpForward);
    }

    public void Move(int direction)
    {
        if (direction < 0)
        {
            _animator.Play(MoveBackward);
            return;
        }

        _animator.Play(MoveForward);
    }
}