using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    public void Explode(Cube destroyedCube, List<Rigidbody> explodableObjects)
    {
        if (explodableObjects != null)
            foreach (Rigidbody explodableObject in explodableObjects)
            {
                explodableObject.AddExplosionForce(destroyedCube.GetExplosionForce(), 
                                                   destroyedCube.transform.position, 
                                                   destroyedCube.GetExplosionRadius()
                                                   );
            }

        destroyedCube.Destroy();
    }
}
