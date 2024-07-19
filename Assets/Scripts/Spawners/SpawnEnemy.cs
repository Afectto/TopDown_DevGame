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
        _enemyStates.Sort((enemy1, enemy2) => enemy1.ChanceToSpawn.CompareTo(enemy2.ChanceToSpawn));
        
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
        Vector2 spawnPosition = GetRandomPositionOutsideCameraButInArea();

        CreateEnemy(spawnPosition);
    }
    
    private Vector2 GetRandomPositionOutsideCameraButInArea()
    {
        Camera mainCamera = Camera.main;
        float offset = 0.5f;
        float cameraHeight = Utils.GetCameraHeight();
        float cameraWidth = Utils.GetCameraWight();

        var position = mainCamera.transform.position;
        var topRightCameraPoint = position + new Vector3(cameraWidth + offset,cameraHeight + offset);
        var leftDownCameraPoint = position + new Vector3(-cameraWidth - offset, -cameraHeight - offset);
        
        Vector2 point = Utils.GetRandomPointInArea();
        
        while (Utils.IsPositionInsideRectangle(point, leftDownCameraPoint,topRightCameraPoint))
        {
            point = Utils.GetRandomPointInArea();
        }

        return point;
    }

    private void CreateEnemy(Vector2 position)
    {
        float totalChance = 0f;
        float randomValue = Random.value;

        foreach (var enemyStats in _enemyStates)
        {
            totalChance += enemyStats.ChanceToSpawn;

            if (randomValue <= totalChance)
            {
                var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
                enemy.Initialize(enemyStats);
                return;
            }
        }
    }
}
