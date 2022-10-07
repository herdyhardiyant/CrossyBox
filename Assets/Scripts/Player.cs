using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _moveDuration = .5f;
    [SerializeField] private float _rotateDuration = .2f;

    void Update()
    {
        var playerCurrentPosition = _playerTransform.position;
        
        if (Input.GetKeyDown("w"))
        {
            _playerTransform.DOMoveZ(playerCurrentPosition.z + 1, _moveDuration);
            _playerTransform.DORotate(new Vector3(0, 0, 0), _rotateDuration);
        }
        else if (Input.GetKeyDown("s"))
        {
            _playerTransform.DOMoveZ(playerCurrentPosition.z + -1, _moveDuration);
            _playerTransform.DORotate(new Vector3(0, 180, 0), _rotateDuration);
        }
        else if (Input.GetKeyDown("a"))
        {
            _playerTransform.DOMoveX(playerCurrentPosition.x + -1, _moveDuration);
            _playerTransform.DORotate(new Vector3(0, -90, 0), _rotateDuration);
        }
        else if (Input.GetKeyDown("d"))
        {
            _playerTransform.DOMoveX(playerCurrentPosition.x + 1, _moveDuration);
            _playerTransform.DORotate(new Vector3(0, 90, 0), _rotateDuration);
        }
    }
}