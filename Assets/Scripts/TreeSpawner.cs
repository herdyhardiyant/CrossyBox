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


    private const int halfRoadCount = 6;

    // Start is called before the first frame update
    void Start()
    {
         List<Vector3> emptySpawnPosition = new List<Vector3>();

        for (int x = -halfRoadCount -1; x <= halfRoadCount; x++)
        {
            if (x == 0 && transform.position.z == 0)
                continue;
            
            emptySpawnPosition.Add(new Vector3(x, 0, transform.position.z));
        }
        
        Instantiate(_treePrefab, emptySpawnPosition[0], Quaternion.identity,
            transform);
        emptySpawnPosition.RemoveAt(0);
        
        Instantiate(_treePrefab, emptySpawnPosition[emptySpawnPosition.Count - 1], Quaternion.identity,
            transform);
        emptySpawnPosition.RemoveAt(emptySpawnPosition.Count - 1);

        
        for (int i = 0; i < _treeCount; i++)
        {
            var chosenPosition = Random.Range(0, emptySpawnPosition.Count);
            Instantiate(_treePrefab, emptySpawnPosition[chosenPosition], Quaternion.identity,
                transform);
            emptySpawnPosition.RemoveAt(chosenPosition);
        }
    }
}