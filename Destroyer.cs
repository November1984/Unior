using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
 [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;
    private ParticleSystem _effect;

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/CFXR Explosion 1");
        _effect = prefab.GetComponent<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        Explode();
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
 
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
    
    private void OnDestroy()
    {
        DestroyEventManager.DestroyedNotify(gameObject);
    }
}
