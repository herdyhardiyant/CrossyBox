using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefabs;
    [SerializeField] private int _roadCountBetweenPlayer = 10;


    void Start()
    {
        int firstLastChosenRoadIndex = -1;
        int secondLastChosenRoadIndex = -1;

        for (int i = -_roadCountBetweenPlayer; i < _roadCountBetweenPlayer; i++)
        {
            var chosenIndex = Random.Range(0, _roadPrefabs.Length);
            

            if (firstLastChosenRoadIndex == -1)
            {
                firstLastChosenRoadIndex = chosenIndex;
                secondLastChosenRoadIndex = -1;
            }
            else if (secondLastChosenRoadIndex == -1)
            {
                secondLastChosenRoadIndex = chosenIndex;

                if (secondLastChosenRoadIndex != firstLastChosenRoadIndex)
                {
                    firstLastChosenRoadIndex = -1;
                }
            }
            
            if (secondLastChosenRoadIndex == firstLastChosenRoadIndex)
            {
                chosenIndex = secondLastChosenRoadIndex == 0 ? 1 : 0;
                firstLastChosenRoadIndex = -1;
                secondLastChosenRoadIndex = -1;
            }
            
            var chosenRoad = _roadPrefabs[chosenIndex];

            Instantiate(chosenRoad, new Vector3(0, 0, i), Quaternion.identity);
        }
    }
}