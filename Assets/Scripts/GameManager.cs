using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly int HalfRoadWidth = 6;
    
    public int Score => _score;

    private int _score;

    public void UpdateScore(int playerForwardSteps)
    {
        if(playerForwardSteps > Score)
        {
            _score = playerForwardSteps;
        }
    }
    
    // TODO Create Game Over Screen


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
