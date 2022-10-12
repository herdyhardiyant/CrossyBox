using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    float _spawnDelay;
    Vector3 _enemyMoveDirection = new Vector3(-1, 0, 0);

    float _spawnTimer = 0f;
    Vector3 _spawnPosition = new Vector3(GameManager.HalfRoadWidth + 1, 0, 0);

    // Start is called before the first frame update

    private void Awake()
    {
        _spawnDelay = Random.Range(0.1f, 1f);

        var randomNumber = Random.Range(0, 10);
        if (randomNumber >= 5)
        {
            _spawnPosition = -_spawnPosition;
            _enemyMoveDirection = -_enemyMoveDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnTimer > _spawnDelay)
        {
            SpawnEnemy();
            _spawnTimer = 0f;
            _spawnDelay = Random.Range(0.5f, 2f);
        }

        _spawnTimer += Time.deltaTime;
    }


    private void SpawnEnemy()
    {
        var enemySpawnPosition = new Vector3(_spawnPosition.x, 0.5f, transform.position.z);
        var enemy = Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.LookRotation(_enemyMoveDirection),
            transform);
    }
}