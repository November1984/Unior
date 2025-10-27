using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private ExplodeView _explodeView;
    [SerializeField] private LayerMask _layerMask;
    
    public void Explode()
    {
        List<Rigidbody> scatterCObjects = ScatterCubes(transform.position);
        
        if (scatterCObjects != null)
        {
            foreach (Rigidbody scatterCObject in scatterCObjects)
            {
                scatterCObject.AddExplosionForce(_explosionForce,
                                                   transform.position,
                                                   _explosionRadius
                                                   );
            }
        }
    }

    public List<Rigidbody> ScatterCubes(Vector3 explosionPosition)
    {
        Collider[] hitObjects = new Collider[30];

        int hitsCount = Physics.OverlapSphereNonAlloc(explosionPosition, _explosionRadius, hitObjects, _layerMask);

        List<Rigidbody> cubes = new();

        foreach (Collider obj in hitObjects)
            if (obj.attachedRigidbody != null)
                cubes.Add(obj.attachedRigidbody);

        return cubes;
    }
}
