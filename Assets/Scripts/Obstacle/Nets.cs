using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Nets : MonoBehaviour
{
    const string Move = nameof(Move);
    const string Idle = nameof(Idle);
    
    private Animator _animator;
    private int _move;
    private int _idle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _move = Animator.StringToHash(Move);
        _idle = Animator.StringToHash(Idle);
    }

    public void Launch()
    {
        _animator.Play(_move);
    }
    
    public void Stop()
    {
        _animator.Play(_idle);
    }
}