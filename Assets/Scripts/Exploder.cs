using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    public void Explode(Cube destroyedCube, List<Rigidbody> explodableObjects)
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

        destroyedCube.Destroy();
    }
}
