using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ExplosionRadius { get; private set; } = 20f;
    public float ExplosionForce { get; private set; } = 700f;
    public int NextGenerationChance { get; private set; } = 100;
    private Boolean isDestroyed = false;
    public ParticleSystem Effect { get; private set; }

    public void SetDestroyed()
    {
        isDestroyed = true;
    }

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/CFXR Explosion 1");
        Effect = prefab.GetComponent<ParticleSystem>();
    }

    public void SetNextGenerationChance(int value)
    {
        NextGenerationChance = value;
    }

    private void OnMouseDown()
    {
        Raycaster.DestroyedNotify(gameObject);
    }

    private void Update()
    {
        if (isDestroyed)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (isDestroyed)
            Instantiate(Effect, transform.position, transform.rotation);
    }
}
