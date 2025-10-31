using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    private Vector3 _newBombPosition;

    public void CreateBomb(Vector3 position)
    {
        _newBombPosition = position;

        GetObj();
    }

    protected override void ActionOnGet(IPoolable obj)
    {
        obj.Transform.gameObject.SetActive(true);
        obj.Init();
        obj.Reset();
        
        obj.Transform.position = _newBombPosition;
        obj.Rigidbody.linearVelocity = Vector3.zero;
        
        SpawnedCount++;
    }
}