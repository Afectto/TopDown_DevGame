using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, ILisener
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponStats baseWeaponStats;
    private IWeaponBehavior _weaponBehavior;
    private float _damage;
    private float _shotPerSecond;
    private WeaponType _weaponType;
    private Transform _playerPosition;

    private void Start()
    {
        AddAllListeners();
        ChangeWeapon(baseWeaponStats);
        _playerPosition = FindFirstObjectByType<Player>().transform;
        StartCoroutine(ShootRoutine());
    }
    
    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && _playerPosition)
            {
                _weaponBehavior?.Shoot(firePoint.position - _playerPosition.position);
                yield return new WaitForSeconds(1/_shotPerSecond);
            }

            yield return null;
        }
        // ReSharper disable once IteratorNeverReturns
    }

    public WeaponType GetCurrentWeaponType()
    {
        return _weaponType;
    }
    
    public void AddAllListeners()
    {
        EventManager.Instance.OnChangeWeapon += ChangeWeapon;
    }

    public void RemoveAllListeners()
    {
        // ReSharper disable once DelegateSubtraction
        EventManager.Instance.OnChangeWeapon -= ChangeWeapon;
    }

    private void ChangeWeapon(WeaponStats weaponStats)
    {
        _shotPerSecond = weaponStats.ShotPerSecond;
        SetWeaponType(weaponStats);
    }
    
    private void SetWeaponType(WeaponStats weaponStats)
    {
        _weaponType = weaponStats.WeaponType;
        switch(weaponStats.WeaponType)
        {
            case WeaponType.Base:
                _weaponBehavior = new DefaultWeaponBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.Pistol:
                _weaponBehavior = new PistolBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.AssaultRifle:
                _weaponBehavior = new AssaultRifleBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.Shotgun:
                _weaponBehavior = new ShotgunBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.GrenadeLauncher:
                _weaponBehavior = new GrenadeLauncherBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            default:
                _weaponBehavior = new DefaultWeaponBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
        }
    }
    
    private void OnDisable()
    {
        RemoveAllListeners();
    }
}