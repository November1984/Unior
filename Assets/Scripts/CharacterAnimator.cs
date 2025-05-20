using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string IsOnGround = nameof(IsOnGround);
    private const string IsJumped = nameof(IsJumped);
    private const string IsLanding = nameof(IsLanding);
    private const string Direction = nameof(Direction);

    private int _isOnGround;
    private int _isJumped;
    private int _isLanding;
    private int _direction;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isOnGround = Animator.StringToHash(IsOnGround);
        _isJumped = Animator.StringToHash(IsJumped);
        _isLanding = Animator.StringToHash(IsLanding);
        _direction = Animator.StringToHash(Direction);
    }

    public void Move(int value)
    {
        _animator.SetInteger(_direction, value);
    }

    public void Idle()
    {
        _animator.SetBool(_isOnGround, true);
        _animator.SetBool(_isJumped, false);
    }

    public void Jump()
    {
        _animator.SetBool(_isJumped, true);
        _animator.SetBool(_isLanding, false);
        _animator.SetBool(_isOnGround, false);
    }

    public void Landing()
    {
        _animator.SetBool(_isLanding, true);
        _animator.SetBool(_isJumped, false);
    }
}
