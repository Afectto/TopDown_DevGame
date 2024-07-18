using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnVoidZone : MonoBehaviour
{
    [SerializeField] private VoidZone voidZonePrefab;
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
            SpawnNewVoidZone(stats);
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
        Vector2 offsetPoint = new Vector2(offset, offset);
        
        var randomPosition = GetRandomPointInNewArea(offsetPoint);
        
        while (Vector2.Distance(randomPosition, Vector2.zero) < offset)
        {
            randomPosition = GetRandomPointInNewArea(offsetPoint);
        }
        
        foreach (var zone in _voidZones)
        {
            while (Vector2.Distance(zone.transform.position, randomPosition) < offset || Vector2.Distance(randomPosition, Vector2.zero) < offset )
            {
                randomPosition = GetRandomPointInNewArea(offsetPoint);
            }
        }
        
        return randomPosition;
    }

    private Vector2 GetRandomPointInNewArea(Vector2 offsetPoint)
    {
        Vector2 newMaxPoint = Utils.MaxLimitsArena - offsetPoint;
        Vector2 newMinPoint = Utils.MinLimitsArena + offsetPoint;
        return Utils.GetRandomPointInArea(newMaxPoint, newMinPoint);
    }
}
