using UnityEngine;

public class GrenadeLauncherBehavior : AbstractWeaponBehavior
{
    public GrenadeLauncherBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }

    public override void Shoot(Vector3 direction)
    {
        var bullet = CreateBullet(direction);
        var grenadeBullet = bullet.GetComponent<GrenadeBullet>();
        if (grenadeBullet)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            grenadeBullet.SetTargetPosition(position);
        }
    }

}