using UnityEngine;

public class ShotgunBehavior : AbstractWeaponBehavior
{
    public ShotgunBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }

    public override void Shoot(Vector3 dir)
    {
        for(int i = 0; i < 5; i++)
        {
            float angle = (i - 2) * 10f;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            var bullet = CreateBullet(rotation, dir);
            bullet.transform.localScale = Vector3.one * 0.75f;
        }
    }

}