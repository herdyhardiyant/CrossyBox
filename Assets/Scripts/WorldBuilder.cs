
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefabs;
    [SerializeField] private int initialRoadSpawnNumber = 20;
    
 
    // TODO use player position to spawn new roads and destroy old roads
    // TODO Update zlimit to be the last road in the array
    
    private int zLimit = -2;
    
    public int ZLimit => zLimit;
    public int LeftLimit => -GameManager.HalfRoadWidth - 1;
    public int RightLimit => GameManager.HalfRoadWidth + 1;
    
    // TODO Infinite road spawning
    // Dequeue road and destroy it
    // Get the last road in the array and set it as the new last road
    // Set ZLimit to the new last road's z position
    private Queue<GameObject> _roads = new Queue<GameObject>();


    void Start()
    {
        BuildSafeRoadForPlayerSpawn();
        BuildRoadWithDangerRoad();
    }

    private void BuildSafeRoadForPlayerSpawn()
    {
        for (int i = zLimit; i <= 0; i++)
        {
            var newRoad = Instantiate(_roadPrefabs[1], new Vector3(0, 0, i), Quaternion.identity, transform);
            
        }
    }

    private void BuildRoadWithDangerRoad()
    {
        for (int i = 1; i < initialRoadSpawnNumber; i++)
        {
            var chosenIndex = Random.Range(0, _roadPrefabs.Length);
            
            if (CheckIsTheLastThreeRoadsAreSame(chosenIndex))
            {
                chosenIndex = chosenIndex == 0 ? 1 : 0;
            }

            var chosenRoad = _roadPrefabs[chosenIndex];

            Instantiate(chosenRoad, new Vector3(0, 0, i), Quaternion.identity, transform);
        }
    }

    private int _firstLastChosenRoadIndex = -1;
    private int _secondLastChosenRoadIndex = -1;
    private int _thirdLastChosenRoadIndex = -1;
    
    private bool CheckIsTheLastThreeRoadsAreSame(int chosenRoadByIndex)
    {
        if (_firstLastChosenRoadIndex == -1)
        {
            _firstLastChosenRoadIndex = chosenRoadByIndex;
            _secondLastChosenRoadIndex = -1;
        }
        else if (_secondLastChosenRoadIndex == -1)
        {
            _secondLastChosenRoadIndex = chosenRoadByIndex;
            _thirdLastChosenRoadIndex = -1;

            if (_secondLastChosenRoadIndex != _firstLastChosenRoadIndex)
            {
                _firstLastChosenRoadIndex = -1;
            }
        }
        else if (_thirdLastChosenRoadIndex == -1)
        {
            _thirdLastChosenRoadIndex = chosenRoadByIndex;

            if (_secondLastChosenRoadIndex != _thirdLastChosenRoadIndex)
            {
                _firstLastChosenRoadIndex = -1;
            }
        }

        if (_secondLastChosenRoadIndex == _firstLastChosenRoadIndex &&
            _secondLastChosenRoadIndex == _thirdLastChosenRoadIndex)
        {
            _firstLastChosenRoadIndex = -1;
            return true;
        }

        return false;

    }
    
    
    
}