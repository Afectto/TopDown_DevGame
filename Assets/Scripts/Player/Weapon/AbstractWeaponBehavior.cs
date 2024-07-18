using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class AbstractWeaponBehavior : IWeaponBehavior
{
    private readonly Bullet _bulletPrefab;
    private readonly Transform _firePoint;
    private readonly float _damage;

    protected AbstractWeaponBehavior(float damage, Transform firePoint, Bullet bulletPrefab)
    {
        _damage = damage;
        _firePoint = firePoint;
        _bulletPrefab = bulletPrefab;
    }
    
    public virtual void Shoot(Vector3 direction)
    {
        CreateBullet(Quaternion.identity, direction);
    }

    protected GameObject CreateBullet(Quaternion rotation, Vector3 dir)
    {
        var bulletObject = GameObject.Instantiate(_bulletPrefab, _firePoint.position, rotation);
        bulletObject.SetDamage(_damage);
        bulletObject.SetDirection(dir);
        return bulletObject.gameObject;
    }
}