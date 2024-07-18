using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<GameObject, float> OnDamageTaken;

    public Action<WeaponStats> OnChangeWeapon;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
