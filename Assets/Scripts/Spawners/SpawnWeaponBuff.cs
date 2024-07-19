using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnWeaponBuff : MonoBehaviour
{
    [SerializeField] private WeaponPickupBuff _prefab;
    private List<WeaponStats> _weaponStats;
    private Weapon _weapon;
    
    void Awake()
    {
        _weapon = FindFirstObjectByType<Weapon>();
        _weaponStats = Resources.LoadAll<WeaponStats>("ScriptableObject/Weapon").ToList();
        StartCoroutine(SpawnWeapon());
    }

    private IEnumerator SpawnWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            int randomIndex = Random.Range(0, _weaponStats.Count);
            while (_weaponStats[randomIndex].WeaponType == _weapon.GetCurrentWeaponType())
            {
                randomIndex = Random.Range(0, _weaponStats.Count);
            }
        
            var position = Utils.GetRandomPositionInCamera();
            var pickup = Instantiate(_prefab, position, Quaternion.identity);
            pickup.Initialize(_weaponStats[randomIndex]);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}
