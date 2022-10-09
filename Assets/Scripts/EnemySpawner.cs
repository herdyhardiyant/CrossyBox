using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = 0.1f;
    Vector3 enemyMoveDirection = new Vector3(-1, 0, 0);

    float spawnTimer = 0f;

    // Start is called before the first frame update

    private void Awake()
    {
        var randomNumber = Random.Range(0, 10);
        if (randomNumber > 5)
        {
            spawnPosition = -spawnPosition;
            enemyMoveDirection = -enemyMoveDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > spawnDelay)
        {
            
            SpawnEnemy();
            spawnTimer = 0f;
            spawnDelay = Random.Range(0.5f, 2f);
        }

        spawnTimer += Time.deltaTime;
    }

  
    private void SpawnEnemy()
    {
        var enemySpawnPosition = new Vector3(spawnPosition.x, 0.5f, transform.position.z);
        var enemy = Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity, transform);
        enemy.transform.rotation = Quaternion.LookRotation(enemyMoveDirection);
    }
}