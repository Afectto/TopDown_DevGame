using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<GameObject, float> OnDamageTaken;

    public Action<WeaponStats> OnChangeWeapon;

    public Action OnEnterDeadZone;
    
    public Action<float> OnEnterSlowZone;
    public Action OnExitSlowZone;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
