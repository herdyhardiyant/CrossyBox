using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distanceFromPlayer;

    // Update is called once per frame
    void Update()
    {
        var playerPosition = _player.position;
        gameObject.transform.position = new Vector3(
            playerPosition.x + _distanceFromPlayer,
            transform.position.y,
            playerPosition.z - _distanceFromPlayer
            );
    }
}