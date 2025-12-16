using UnityEngine;
using DG.Tweening;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _height = 4;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private int _loops = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;

    private void Start()
    {
        DOTween.Init();
        transform.DOMoveY(_height, _duration).SetLoops(_loops, _loopType);
    }
}