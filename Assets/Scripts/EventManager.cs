using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<GameObject, float> OnDamageTaken;

    public Action<WeaponStats> OnChangeWeapon;

    public Action OnEnterDeadZone;
    
    public Action<float> OnEnterSlowZone;
    public Action<float> OnExitSlowZone;

    public Action<BuffStats> OnPickupBuff;
    
    public Action<float> OnDeadEnemy;
    public Action OnDeadPlayer;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
