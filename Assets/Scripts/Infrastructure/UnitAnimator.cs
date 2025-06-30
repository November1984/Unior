using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]

public class UnitAnimator : MonoBehaviour
{
    const string JumpForward = nameof(JumpForward);
    const string JumpBackward = nameof(JumpBackward);
    const string MoveForward = nameof(MoveForward);
    const string MoveBackward = nameof(MoveBackward);
    const string Idle = nameof(Idle);

    private Animator _animator;
    private Coroutine _coroutine;
    private int _moveDirection;

    public int MoveDirection
    {
        get => _moveDirection;
        set
        {
            _moveDirection = value;
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jumping()
    {
        _coroutine = StartCoroutine(JumpForcing());
    }

    public void MoveOnGround()
    {
        if (_moveDirection >= 0)
            _animator.Play(MoveForward);
        else
            _animator.Play(MoveBackward);
    }

    public void Standing()
    {
        _animator.Play(Idle);
    }

    private IEnumerator JumpForcing()
    {
        WaitForEndOfFrame waitForEndOfFrame = new();
        bool canJump = true;

        while (canJump)
        {
            yield return waitForEndOfFrame;

            if (_moveDirection >= 0)
                _animator.Play(JumpForward);
            else
                _animator.Play(JumpBackward);

            canJump = false;
        }

        StopCoroutine(_coroutine);
    }
}