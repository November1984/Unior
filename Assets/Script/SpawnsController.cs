using UnityEngine;

public class SpawnsController : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void OnEnable()
    {
        _cubeSpawner.ObjCollected += CreateBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.ObjCollected -= CreateBomb;
    }

    private void CreateBomb(IPoolable obj)
    {
        _bombSpawner.CreateBomb(obj.Transform.position);
    }
}