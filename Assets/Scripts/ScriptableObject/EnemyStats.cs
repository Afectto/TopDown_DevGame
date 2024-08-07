﻿using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyStats", menuName = "Enemy Stats Object", order = 10)]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float reward;
    [SerializeField, Range(0, 1)] private float chanceToSpawn;
    [SerializeField] private SpriteRenderer skin;
    
    public float Health => health;
    public float Speed => speed;
    public float Reward => reward;
    public float ChanceToSpawn => chanceToSpawn;
    public SpriteRenderer Skin => skin;

}