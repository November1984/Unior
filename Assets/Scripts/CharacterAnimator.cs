using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string IsOnGround = nameof(IsOnGround);
    private const string IsJumped = nameof(IsJumped);
    private const string IsLanding = nameof(IsLanding);
    private const string IsStanding = nameof(IsStanding);
    private const string Direction = nameof(Direction);

    private int _isOnGround;
    private int _isJumped;
    private int _isLanding;
    private int _isStanding;
    private int _direction;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isOnGround = Animator.StringToHash(IsOnGround);
        _isJumped = Animator.StringToHash(IsJumped);
        _isLanding = Animator.StringToHash(IsLanding);
        _isStanding = Animator.StringToHash(IsStanding);
        _direction = Animator.StringToHash(Direction);
    }

    public void Move(float value)
    {
        _animator.SetFloat(_direction, value);
        _animator.SetBool(_isStanding, false);
    }

    public void Idle()
    {
        _animator.SetBool(_isOnGround, true);
        _animator.SetBool(_isStanding, true);
        _animator.SetBool(_isLanding, false);
        _animator.SetBool(_isJumped, false);
        _animator.SetFloat(_direction, 0);
    }

    public void Jump()
    {
        _animator.SetBool(_isJumped, true);
        _animator.SetBool(_isLanding, false);
        _animator.SetBool(_isOnGround, false);
        _animator.SetBool(_isStanding, false);
    }

    public void Landing()
    {
        _animator.SetBool(_isLanding, true);
        _animator.SetBool(_isJumped, false);
    }
}
