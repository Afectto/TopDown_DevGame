using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, ILisener
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponStats baseWeaponStats;
    private IWeaponBehavior weaponBehavior;
    private float _damage;
    private float _shotPerSecond;
    private WeaponType _weaponType;
    private Transform _playerPosition;
    
    private void Start()
    {
        ChangeWeapon(baseWeaponStats);
        _playerPosition = FindFirstObjectByType<Player>().transform;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (Input.GetMouseButton(0))
        {
            weaponBehavior?.Shoot(firePoint.position - _playerPosition.position);
            yield return new WaitForSeconds(1/_shotPerSecond);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    public WeaponType GetCurrentWeaponType()
    {
        return _weaponType;
    }
    
    private void OnEnable()
    {
        AddAllListeners();
    }

    public void AddAllListeners()
    {
        // EventManager.Instance.OnChangeWeapon += ChangeWeapon;
    }

    public void RemoveAllListeners()
    {
        // EventManager.Instance.OnChangeWeapon -= ChangeWeapon;
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
                weaponBehavior = new DefaultWeaponBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.Pistol:
                weaponBehavior = new PistolBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.AssaultRifle:
                weaponBehavior = new AssaultRifleBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.Shotgun:
                weaponBehavior = new ShotgunBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            case WeaponType.GrenadeLauncher:
                weaponBehavior = new GrenadeLauncherBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
            default:
                weaponBehavior = new DefaultWeaponBehavior(weaponStats.Damage, firePoint, weaponStats.BulletPrefab);
                break;
        }
    }
    
    private void OnDisable()
    {
        RemoveAllListeners();
    }
}