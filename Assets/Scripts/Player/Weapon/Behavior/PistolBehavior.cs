using UnityEngine;

public class PistolBehavior : AbstractWeaponBehavior
{
    public PistolBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }
}