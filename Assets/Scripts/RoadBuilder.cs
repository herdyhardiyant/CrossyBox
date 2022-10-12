using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;

    private int _halfRoadCount = GameManager.HalfRoadWidth;

    void Start()
    {
        AddCenterRoad();
        
        for (int i = -_halfRoadCount; i < _halfRoadCount; i++)
        {
            Instantiate(roadPrefab, new Vector3(i, 0, transform.position.z), Quaternion.identity, transform);
        }
    }

    private void AddCenterRoad()
    {
        _halfRoadCount += 1;
    }

}