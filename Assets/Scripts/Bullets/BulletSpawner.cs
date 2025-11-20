public class BulletSpawner : ObjectPool<Bullet>
{
    protected override void Subscribe(Bullet obj)
    {
        obj.Collided += Collect;
    }

    private void Collect(Bullet obj)
    {
        obj.Collided -= Collect;

        PutObject(obj);
    }
}