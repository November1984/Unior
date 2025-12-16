using UnityEngine;
using DG.Tweening;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _duration = 3f;
    [SerializeField] private float _scale = 2f;
    [SerializeField] private int _loops = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;

    private void Start()
    {
        transform.DOScale(_scale, _duration).SetLoops(_loops, _loopType);
    }
}