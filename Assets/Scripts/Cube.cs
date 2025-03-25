using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public float ExplosionRadius { get; private set; } = 20f;
    public float ExplosionForce { get; private set; } = 700f;
    public int NextGenerationChance { get; private set; } = 100;
    public event Action<Cube> CubeDestroyed;

    private void OnMouseDown()
    {
        DestroyedNotify(this);
    }

    public void DestroyedNotify(Cube destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }

    public void SetEffect(ParticleSystem value)
    {
        _effect = value;
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
