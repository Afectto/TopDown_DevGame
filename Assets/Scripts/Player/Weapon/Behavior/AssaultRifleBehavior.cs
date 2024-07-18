using UnityEngine;

public class AssaultRifleBehavior : AbstractWeaponBehavior
{
    public AssaultRifleBehavior(float damage, Transform firePoint, Bullet bulletPrefab) : base(damage, firePoint, bulletPrefab)
    {
    }
}