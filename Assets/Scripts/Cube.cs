using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private float _coefficient = 10f;

    public event Action<Cube> CubeDestroyed;

    public int NextGenerationChance { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }

    private void OnEnable()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        DestroyedNotify(this);
    }

    public float GetExplosionRadius()
    {
        return _explosionRadius;
    }

    public float GetExplosionForce()
    {
        return _explosionForce;
    }

    public void IncreaseExplosionRadius()
    {
        _explosionRadius *= _coefficient;
    }

    public void IncreaseExplosionForce()
    {
        _explosionForce *= _coefficient;
    }

    public void SetNextGenerationChance(int value)
    {
        NextGenerationChance = value;
    }

    public void DestroyedNotify(Cube destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }

    public void Destroy()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
}
