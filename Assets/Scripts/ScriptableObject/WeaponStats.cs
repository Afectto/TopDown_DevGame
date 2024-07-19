using UnityEngine;

public enum WeaponType
{
    Base,
    Pistol,
    AssaultRifle,
    Shotgun,
    GrenadeLauncher
}

[CreateAssetMenu(fileName = "New WeaponStats", menuName = "Weapon Stats Object", order = 10)]
public class WeaponStats : ScriptableObject, IStats
{
    [SerializeField] private float damage;
    [SerializeField] private float shotPerSecond;
    [SerializeField] private WeaponType type;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private SpriteRenderer skin;

    public float Damage => damage;
    public float ShotPerSecond => shotPerSecond;
    public WeaponType WeaponType => type;
    public Bullet BulletPrefab => _bulletPrefab;
    public SpriteRenderer Skin => skin;
}

public interface IStats
{
}
