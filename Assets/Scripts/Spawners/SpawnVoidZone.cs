using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnVoidZone : MonoBehaviour
{
    [SerializeField] private VoidZone voidZonePrefab;
    [SerializeField] private int slowZoneCount = 3;
    [SerializeField] private int deadZoneCount = 2;
    private List<VoidZoneStats> _voidZoneStates;
    private List<VoidZone> _voidZones;
    
    private void Awake()
    {
        _voidZoneStates = Resources.LoadAll<VoidZoneStats>("ScriptableObject/VoidZone").ToList();
        _voidZones = new List<VoidZone>();
    }

    void Start()
    {
        SpawnAllZone();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     for (int i = 0; i < _voidZones.Count; i++)
        //     {
        //         Destroy(_voidZones[i].gameObject);
        //     }
        //     _voidZones.Clear();
        //     SpawnAllZone();
        // } //DEBUG
    }

    private void SpawnAllZone()
    {
        foreach (var stats in _voidZoneStates)
        {
            switch (stats.Type)
            {
                case VoidZoneType.Slow: 
                    for (int i = 0; i < slowZoneCount; i++)
                    {
                        SpawnNewVoidZone(stats);
                    }
                    break;
                case VoidZoneType.Dead: 
                    for (int i = 0; i < deadZoneCount; i++)
                    {
                        SpawnNewVoidZone(stats);
                    }
                    break;
            }
        }
    }
    
    private void SpawnNewVoidZone(VoidZoneStats voidZoneState)
    {
        var randomPosition = GetCorrectRandomPosition(voidZoneState.Radius);
        var zone = Instantiate(voidZonePrefab, randomPosition, Quaternion.identity);
        zone.Initialize(voidZoneState);
        
        _voidZones.Add(zone);
    }

    private Vector2 GetCorrectRandomPosition(float radius)
    {
        float offset = 3f + radius;
        Vector2 randomPosition;
        var offsetPoint = new Vector2(offset, offset);

        do
        {
            randomPosition = GetRandomPointInNewArea(offsetPoint);
        } while (!IsPositionValid(randomPosition, radius));

        return randomPosition;
    }
    
    private bool IsPositionValid(Vector2 position, float radius)
    {    
        float distanceToOrigin = Vector2.Distance(position, Vector2.zero);
        if (distanceToOrigin <= radius + 3f)
        {
            return false;
        }
        
        foreach (var zone in _voidZones)
        {
            float zoneRadius = zone.GetRadius();
            float distanceToZone = Vector2.Distance(zone.transform.position, position);
            float requiredDistance = zoneRadius + radius + 3f;

            if (distanceToZone < requiredDistance)
            {
                return false;
            }
        }
        return true;
    }
    
    private Vector2 GetRandomPointInNewArea(Vector2 offsetPoint)
    {
        Vector2 newMaxPoint = Utils.MaxLimitsArena - offsetPoint;
        Vector2 newMinPoint = Utils.MinLimitsArena + offsetPoint;
        return Utils.GetRandomPointInArea(newMaxPoint, newMinPoint);
    }
}
