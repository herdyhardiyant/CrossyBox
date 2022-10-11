using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;

    private int _halfRoadCount = 6;

    void Start()
    {
        
        _halfRoadCount += 1;
        for (int i = -_halfRoadCount; i < _halfRoadCount; i++)
        {
            Instantiate(roadPrefab, new Vector3(i, 0, transform.position.z), Quaternion.identity, transform);
        }
    }

}