using System;
using UnityEngine;

public static class Raycaster
{
    public static event Action<GameObject> CubeDestroyed;
    
    public static void DestroyedNotify(GameObject destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }
}
