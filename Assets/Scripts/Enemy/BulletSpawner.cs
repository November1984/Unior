using UnityEngine;

public class BulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] private BulletTerminator _terminator;

    private void OnEnable()
    {
        _terminator.Terminated += Collect;
    }

    private void OnDisable()
    {
        _terminator.Terminated -= Collect;
    }

    private void Collect(Bullet obj)
    {
        PutObject(obj);
    }
}