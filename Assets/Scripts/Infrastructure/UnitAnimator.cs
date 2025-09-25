using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    const string JumpForward = nameof(JumpForward);
    const string JumpBackward = nameof(JumpBackward);
    const string MoveForward = nameof(MoveForward);
    const string MoveBackward = nameof(MoveBackward);
    const string Idle = nameof(Idle);
    const string Talk = nameof(Talk);
    const string EnemyTalk = nameof(EnemyTalk);

    private Animator _animator;
    private Coroutine _coroutine;
    private int _moveDirection;
    private int _jumpForward;
    private int _jumpBackward;
    private int _moveForward;
    private int _moveBackward;
    private int _idle;
    private int _talk;

    public int MoveDirection
    {
        set
        {
            _moveDirection = value;
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _jumpForward = Animator.StringToHash(JumpForward);
        _jumpBackward = Animator.StringToHash(JumpBackward);
        _moveForward = Animator.StringToHash(MoveForward);
        _moveBackward = Animator.StringToHash(MoveBackward);
        _idle = Animator.StringToHash(Idle);
        _talk = Animator.StringToHash(Talk);
    }

    public void Jumping()
    {
        _coroutine = StartCoroutine(JumpForcing());
    }

    public void MoveOnGround()
    {
        if (_moveDirection >= 0)
            _animator.Play(_moveForward);
        else
            _animator.Play(_moveBackward);
    }

    public void Standing()
    {
        _animator.Play(_idle);
    }

    public void Attacking()
    {
        _animator.Play(_idle);
    }

    private IEnumerator JumpForcing()
    {
        WaitForEndOfFrame waitForEndOfFrame = new();
        bool canJump = true;

        while (canJump)
        {
            yield return waitForEndOfFrame;

            if (_moveDirection >= 0)
                _animator.Play(_jumpForward);
            else
                _animator.Play(_jumpBackward);

            canJump = false;
        }

        StopCoroutine(_coroutine);
    }
}