using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnDelay = 2;
    private List<EnemyStats> _enemyStates;

    private void Awake()
    {
        _enemyStates = Resources.LoadAll<EnemyStats>("ScriptableObject/Enemy").ToList();
        StartCoroutine(DecreaseSpawnDelay());
        StartCoroutine(Spawn());
    }

    private IEnumerator DecreaseSpawnDelay()
    {
        while (spawnDelay > 0.5)
        {
            yield return new WaitForSeconds(10);
            spawnDelay -= 0.1f;
        }
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void SpawnRandomEnemy()
    {        
        var randomEnemyIndex = Random.Range(0, _enemyStates.Count);
        Vector2 spawnPosition = Constants.GetRandomPositionOutsideCameraButInArea();

        CreateEnemy(spawnPosition, randomEnemyIndex);
    }
    
    private void CreateEnemy(Vector2 position, int index)
    {        
        var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.Initialize(_enemyStates[index]);
    }
}
