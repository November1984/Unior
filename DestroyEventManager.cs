using System;
using UnityEngine;

public static class DestroyEventManager 
{
    public static event Action<GameObject> CubeDestroyed;

    public static void DestroyedNotify(GameObject destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }
}
