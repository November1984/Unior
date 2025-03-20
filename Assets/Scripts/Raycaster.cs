using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event Action<GameObject> CubeDestroyed;
    
    public void DestroyedNotify(GameObject destroyedObject)
    {
        CubeDestroyed?.Invoke(destroyedObject);
    }
}
