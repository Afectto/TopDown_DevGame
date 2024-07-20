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
        CreateBullet( direction);
    }

    protected GameObject CreateBullet(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        var bulletObject = GameObject.Instantiate(_bulletPrefab, _firePoint.position, rotation);
        bulletObject.SetDamage(_damage);
        bulletObject.SetDirection(dir);
        return bulletObject.gameObject;
    }
}