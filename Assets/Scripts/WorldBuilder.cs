using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefabs;
    [SerializeField] private int _roadCountBetweenPlayer = 10;
    
    void Start()
    {
        BuildSafeRoadForPlayerSpawn();
        BuildRoadWithDangerRoad();
    }

    private void BuildSafeRoadForPlayerSpawn()
    {
        for (int i = -2; i <= 0; i++)
        {
            Instantiate(_roadPrefabs[1], new Vector3(0, 0, i), Quaternion.identity, transform);
        }
    }

    private void BuildRoadWithDangerRoad()
    {
        for (int i = 1; i < _roadCountBetweenPlayer; i++)
        {
            var chosenIndex = Random.Range(0, _roadPrefabs.Length);
            
            if (CheckIsTheLastThreeRoadsAreSame(chosenIndex))
            {
                chosenIndex = secondLastChosenRoadIndex == 0 ? 1 : 0;
            }

            var chosenRoad = _roadPrefabs[chosenIndex];

            Instantiate(chosenRoad, new Vector3(0, 0, i), Quaternion.identity, transform);
        }
    }
    
    int firstLastChosenRoadIndex = -1;
    int secondLastChosenRoadIndex = -1;
    int thirdLastChosenRoadIndex = -1;
    
    private bool CheckIsTheLastThreeRoadsAreSame(int chosenRoadByIndex)
    {
        if (firstLastChosenRoadIndex == -1)
        {
            firstLastChosenRoadIndex = chosenRoadByIndex;
            secondLastChosenRoadIndex = -1;
        }
        else if (secondLastChosenRoadIndex == -1)
        {
            secondLastChosenRoadIndex = chosenRoadByIndex;
            thirdLastChosenRoadIndex = -1;

            if (secondLastChosenRoadIndex != firstLastChosenRoadIndex)
            {
                firstLastChosenRoadIndex = -1;
            }
        }
        else if (thirdLastChosenRoadIndex == -1)
        {
            thirdLastChosenRoadIndex = chosenRoadByIndex;

            if (secondLastChosenRoadIndex != thirdLastChosenRoadIndex)
            {
                firstLastChosenRoadIndex = -1;
            }
        }

        if (secondLastChosenRoadIndex == firstLastChosenRoadIndex &&
            secondLastChosenRoadIndex == thirdLastChosenRoadIndex)
        {
            firstLastChosenRoadIndex = -1;
            return true;
        }

        return false;

    }
    
    
    
}