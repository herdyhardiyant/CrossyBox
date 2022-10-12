using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private int _treeCount;
    [SerializeField] private GameObject _treePrefab;


    private int _halfRoadCount = GameManager.HalfRoadWidth;
    readonly List<Vector3> _emptySpawnPosition = new List<Vector3>();

    private void Awake()
    {
        _halfRoadCount = GameManager.HalfRoadWidth;
    }

    // Start is called before the first frame update
    void Start()
    {
        StoreAllEmptySpawnPositionOnTheRoad();
        AddTreeToTheEdgeOfTheRoad();
        SpawnTreesOnEmptySpotRandomly();
    }

    private void SpawnTreesOnEmptySpotRandomly()
    {
        for (int i = 0; i < _treeCount; i++)
        {
            var chosenPosition = Random.Range(0, _emptySpawnPosition.Count);
            Instantiate(_treePrefab, _emptySpawnPosition[chosenPosition], Quaternion.identity,
                transform);
            _emptySpawnPosition.RemoveAt(chosenPosition);
        }
    }

    private void AddTreeToTheEdgeOfTheRoad()
    {
        Instantiate(_treePrefab, _emptySpawnPosition[0], Quaternion.identity,
            transform);
        _emptySpawnPosition.RemoveAt(0);

        Instantiate(_treePrefab, _emptySpawnPosition[_emptySpawnPosition.Count - 1], Quaternion.identity,
            transform);
        _emptySpawnPosition.RemoveAt(_emptySpawnPosition.Count - 1);
    }

    private void StoreAllEmptySpawnPositionOnTheRoad()
    {
        for (int x = -_halfRoadCount - 1; x <= _halfRoadCount; x++)
        {
            if (x == 0 && transform.position.z == 0)
                continue;

            _emptySpawnPosition.Add(new Vector3(x, 0, transform.position.z));
        }
    }
}