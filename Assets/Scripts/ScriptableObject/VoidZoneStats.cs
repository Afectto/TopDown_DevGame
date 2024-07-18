using UnityEngine;

[CreateAssetMenu(fileName = "New VoidZoneStats", menuName = "Void Zone Stats Object", order = 10)]
public class VoidZoneStats : ScriptableObject
{
    [SerializeField]private VoidZoneType type;
    [SerializeField, Range(0, 1)] private float value;
    [SerializeField] private SpriteRenderer skin;
    [SerializeField] private float radius;

    public VoidZoneType Type => type;
    public float Value => value;
    public SpriteRenderer Skin => skin;
    public float Radius => radius;
}
