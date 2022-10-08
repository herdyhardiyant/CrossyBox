using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _moveDuration = .5f;
    [SerializeField] private float _rotateDuration = .2f;
    [SerializeField] private float _jumpPower = 0.5f;

    private Sequence _sequence;

    void Update()
    {
        var playerCurrentPosition = _playerTransform.position;

        if (_sequence == null || !_sequence.IsActive())
        {
            if (Input.GetKey("w"))
            {
                _sequence = _playerTransform.DOJump(playerCurrentPosition + Vector3.forward, _jumpPower, 1,
                    _moveDuration);
                _playerTransform.DORotate(new Vector3(0, 0, 0), _rotateDuration);
            }
            else if (Input.GetKey("s"))
            {
                _sequence = _playerTransform.DOJump(playerCurrentPosition + Vector3.back, _jumpPower, 1, _moveDuration);
                _playerTransform.DORotate(new Vector3(0, 180, 0), _rotateDuration);
            }
            else if (Input.GetKey("a"))
            {
                _sequence = _playerTransform.DOJump(playerCurrentPosition + Vector3.left, _jumpPower, 1, _moveDuration);
                _playerTransform.DORotate(new Vector3(0, -90, 0), _rotateDuration);
            }
            else if (Input.GetKey("d"))
            {
                _sequence = _playerTransform.DOJump(playerCurrentPosition + Vector3.right, _jumpPower, 1,
                    _moveDuration);
                _playerTransform.DORotate(new Vector3(0, 90, 0), _rotateDuration);
            }
        }
    }
}