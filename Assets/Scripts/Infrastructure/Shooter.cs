using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private BasketBullets _basketBullets;

    public void Shoot(Vector3 attackDirection, Collider2D collider, string bulletLayer, float initialSpeed = 0f)
    {
        Bullet bullet = GetBullet(bulletLayer);
        float _gunOffset = GetGunOffset(collider, bullet);
        Vector3 bulletSpawnPoint = GetSpawnPoint(_gunOffset, attackDirection);

        bullet.SetParams(bulletSpawnPoint, attackDirection, initialSpeed);
    }

    private Bullet GetBullet(string bulletLayer)
    {
        Bullet bullet = _bulletSpawner.GetObj(_basketBullets.transform);
        bullet.gameObject.layer = LayerMask.NameToLayer(bulletLayer);

        return bullet;
    }

    private float GetGunOffset(Collider2D collider, Bullet bullet)
    {
        float halfColliderSize = collider.bounds.size.x / 2;
        return halfColliderSize + bullet.Collider.bounds.size.x;
    }

    private Vector3 GetSpawnPoint(float gunOffset, Vector3 attackDirection)
    {
        return transform.position + gunOffset * attackDirection;
    }
}