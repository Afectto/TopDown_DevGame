using System;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer skin;
    private float _radius;
    private CircleCollider2D _collider;
    
    private IVoidZoneBehavior _voidZoneBehavior;

    public void Initialize(VoidZoneStats stats)
    {
        _collider = GetComponent<CircleCollider2D>();
        _collider.radius = stats.Radius;
        skin.color = stats.Skin.color;
        skin.transform.localScale = Vector3.one * stats.Radius * 2f;
        SetBehavior(stats.Type, stats.Value);
    }

    private void SetBehavior(VoidZoneType type, float value)
    {
        switch (type)
        {
            case VoidZoneType.Dead:
                _voidZoneBehavior = new DeadVoidZoneBehavior();
                break;
            case VoidZoneType.Slow:
                _voidZoneBehavior = new SlowVoidZoneBehavior(value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _voidZoneBehavior.Apply();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _voidZoneBehavior.Remove();
        }
    }
}