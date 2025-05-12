using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
public class MovementAnimator : MonoBehaviour
{
    private IAnimateAble _object;
    private IMover _movement;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<IMover>();
        _object = GetComponent<IAnimateAble>();

        _movement.ObjectMoved += SetMove;
        _movement.ObjectJumped += SetJump;
    }

    private void OnDisable()
    {
        _movement.ObjectMoved -= SetMove;
        _movement.ObjectJumped -= SetJump;
    }

    private void SetMove(int value) => _animator.SetInteger("Direction", value);

    private void SetJump(bool value)
    {
        if (_object.IsGrounded && value)
        {
            _animator.SetBool("IsJumped", true);
            _animator.SetBool("IsOnGround", false);
        }
        else if (_object.IsGrounded && value == false)
        { _animator.SetBool("IsOnGround", true); }
        else
        {
            _animator.SetBool("IsLanded", true);
            _animator.SetBool("IsJumped", value);
        }
    }
}
