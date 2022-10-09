using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private int _halfRoadCount;
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        _halfRoadCount *= 2;
        _halfRoadCount += 1;
        for (int i = -_halfRoadCount; i < _halfRoadCount; i++)
        {
            Instantiate(roadPrefab, new Vector3(i, 0, transform.position.z), Quaternion.identity, transform);
        }
    }

}