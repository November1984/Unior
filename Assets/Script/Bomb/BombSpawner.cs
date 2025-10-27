using UnityEngine;
public class BombSpawner : Spawner<Bomb>
{
    private Vector3 _newBombPosition;

    public void CreateBomb(Vector3 position)
    {
        _newBombPosition = position;

        ActionOnGet(Create());
    }

    protected override void ActionOnGet(IPoolable obj)
    {
        obj.Transform.position = _newBombPosition;
        obj.Rigidbody.linearVelocity = Vector3.zero;
    }
}