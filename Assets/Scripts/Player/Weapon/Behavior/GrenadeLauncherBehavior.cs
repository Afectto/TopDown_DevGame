using UnityEngine;

public class GrenadeLauncherBehavior : AbstractWeaponBehavior
{
    public GrenadeLauncherBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }

    public override void Shoot(Vector3 direction)
    {
        var bullet = CreateBullet(Quaternion.identity, direction);
        var grenadeBullet = bullet.GetComponent<GrenadeBullet>();
        if (grenadeBullet)
        {
            grenadeBullet.SetTargetPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

}