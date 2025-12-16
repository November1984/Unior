using UnityEngine;
using DG.Tweening;
public class Cube : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration = 0.1f;
    [SerializeField] private RotateMode _rotateMode = RotateMode.Fast;
    [SerializeField] private int _loops = -1;
    [SerializeField] private LoopType _loopType = LoopType.Incremental;

    private void Start()
    {
        transform.DORotate(_position, _duration, _rotateMode).SetLoops(_loops, _loopType);
    }
}