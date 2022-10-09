using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadEnemy : MonoBehaviour
{
    public void MoveEnemy()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }

    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        
        // if initial position is more than 15 units away from current position, destroy the object
        if (Vector3.Distance(initialPosition, transform.position) > 15)
        {
            print("destroyed");
            Destroy(gameObject);
        }
        
    }
}