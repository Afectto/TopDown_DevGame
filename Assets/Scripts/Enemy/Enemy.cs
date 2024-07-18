using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ILisener
{
    private Health _health;
    private EnemyMovement _enemyMovement;

    private bool _isInvulnerability;
    
    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _isInvulnerability = false;

    }

    public void Initialize(EnemyStats stats)
    {
        _health.SetMaxHeath(stats.Health);
        _enemyMovement.SetSpeed(stats.Speed);
    }

    private void OnEnable()
    {
        AddAllListeners();
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }
    
    public void AddAllListeners()
    {
        _health.OnDead += OnDead;
    }

    public void RemoveAllListeners()
    {
        _health.OnDead -= OnDead;
    }
    private void OnDisable()
    {
        RemoveAllListeners();
    }
}