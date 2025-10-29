using UnityEngine;

public abstract class ISpawner : MonoBehaviour
{
    public int SpawnedCount { get; protected set; }
    public int CreatedCount { get; protected set; }
    public int ActiveCount { get; protected set; }
}