using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Contactor : MonoBehaviour
{
    [SerializeField] private float _closeDistance = 2.5f;
    
    public event Action<IDamageable> UnitSpotted;

    private bool _isUnitSpotted = false;
    private IDamageable _spottedUnit;

    public bool IsUnitSpoted => _isUnitSpotted;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = _closeDistance;
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out _spottedUnit))
        {
            _isUnitSpotted = true;
            UnitSpotted?.Invoke(_spottedUnit);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out _spottedUnit))
        {
            UnitSpotted?.Invoke(_spottedUnit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out _spottedUnit))
        {
            _isUnitSpotted = false;
            UnitSpotted?.Invoke(_spottedUnit);
        }
    }
}