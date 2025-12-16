using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color = Color.darkGreen;
    [SerializeField] private float _duration = 3f;

    private MeshRenderer _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _renderer.material.DOColor(_color, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}