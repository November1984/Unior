using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NetAnimator : MonoBehaviour
{
    const string MoveNet = nameof(MoveNet);
    const string Idle = nameof(Idle);
    
    private Animator _animator;
    private int _moveNet;
    private int _idle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveNet = Animator.StringToHash(MoveNet);
        _idle = Animator.StringToHash(Idle);
    }

    public void Launch()
    {
        _animator.Play(_moveNet);
    }
    
    public void Stop()
    {
        _animator.Play(_idle);
    }
}