using UnityEngine;

public class DefaultWeaponBehavior : AbstractWeaponBehavior
{
    public DefaultWeaponBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }
}