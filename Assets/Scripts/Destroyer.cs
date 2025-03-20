using System.Collections.Generic;
using UnityEngine;

public class Destroyer
{
    public void ExplodeCube(GameObject destroyedObject, List<Rigidbody> explodableObjects)
    {
        Explode(explodableObjects);

        Cube destroyedCube = destroyedObject.GetComponent<Cube>();
        destroyedCube.SetDestroyed();
    }

    public void Explode(List<Rigidbody> explodableObjects)
    {
        if (explodableObjects != null)
            foreach (Rigidbody explodableObject in explodableObjects)
            {
                Cube explodableCube = explodableObject.GetComponent<Cube>();
                explodableObject.AddExplosionForce(explodableCube.ExplosionForce, 
                                                   explodableCube.transform.position, 
                                                   explodableCube.ExplosionRadius
                                                   );
            }
    }
}
