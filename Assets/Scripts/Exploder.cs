using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    public void Explode(Cube destroyedCube, List<Rigidbody> explodableObjects)
    {
        if (explodableObjects != null)
        {
            foreach (Rigidbody explodableObject in explodableObjects)
            {
                explodableObject.AddExplosionForce(destroyedCube.GetExplosionForce(),
                                                   destroyedCube.transform.position,
                                                   destroyedCube.GetExplosionRadius()
                                                   );
            }
        }
        
        destroyedCube.Destroy();
    }

    public List<Rigidbody> ScatterCubes(Cube destroyedCube)
    {
        Collider[] hits = Physics.OverlapSphere(destroyedCube.transform.position, destroyedCube.GetExplosionRadius());

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
