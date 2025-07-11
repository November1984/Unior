using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputReader))]

public class UnitFight : MonoBehaviour
{
    [SerializeField] private float _hitForce = 5;

    public bool IsHitting { get; private set; }

    private Health _health;
    private InputReader _inputReader;

    public float HitDistance => 1f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.IsHitting += HittingNotify;
    }

    private void OnDisable()
    {
        _inputReader.IsHitting -= HittingNotify;
    }

    public void Damage(float value)
    {
        _health.Decrease(value);
    }

    private void HittingNotify(bool value)
    {
        IsHitting = value;
    }
}