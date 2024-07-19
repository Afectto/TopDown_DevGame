using UnityEngine;

[CreateAssetMenu(fileName = "New BuffStats", menuName = "Buff Stats Object", order = 10)]
public class BuffStats : ScriptableObject, IStats
{
    [SerializeField] private BuffType type;
    [SerializeField] private float value;
    [SerializeField] private float duration = 10;
    [SerializeField] private SpriteRenderer skin;

    public BuffType Type => type;
    public float Value => value;
    public float Duration => duration;
    public SpriteRenderer Skin => skin;

    public IBuff CreateBuff()
    {
        switch (type)
        {
            case BuffType.Speed:
                return new SpeedBuff(this);
            case BuffType.Invulnerability:
                return new InvulnerabilityBuff(this);
            // Добавьте другие типы баффов
            default:
                return null;
        }
    }
}