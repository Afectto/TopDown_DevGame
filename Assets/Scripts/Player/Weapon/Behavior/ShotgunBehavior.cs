using UnityEngine;

public class ShotgunBehavior : AbstractWeaponBehavior
{
    private const float ShotAngle = 10f;
    private const int BulletCount = 5;

    public ShotgunBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }

    public override void Shoot(Vector3 dir)
    {
        float halfAngle = ShotAngle / 2f;
        float angleStep = ShotAngle / (BulletCount - 1);

        for (int i = 0; i < BulletCount; i++)
        {
            float angle = -halfAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Vector2 shotDirection = rotation * dir;
            var bullet = CreateBullet(rotation, shotDirection);
            bullet.transform.localScale = Vector3.one * 0.75f;
        }
    }
    
}