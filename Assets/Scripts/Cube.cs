using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _coefficient = 10f;

    public float ExplosionRadius { get; private set; } = 2f;
    public float ExplosionForce { get; private set; } = 200f;
    public int NextGenerationChance { get; private set; } = 100;
    public event Action<Cube> CubeDestroyed;

    private void OnMouseDown()
    {
        DestroyedNotify(this);
    }

    public void IncreaseExplosionRadius()
    {
        ExplosionRadius *= _coefficient;
    }

    public void IncreaseExplosionForce()
    {
        ExplosionForce *= _coefficient;
    }

    public void DestroyedNotify(Cube destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }

    public void SetNextGenerationChance(int value)
    {
        NextGenerationChance = value;
    }

    public void Destroy()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
