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

        if (Vector3.Distance(initialPosition, transform.position) > 15)
        {
            Destroy(gameObject);
        }
    }
}