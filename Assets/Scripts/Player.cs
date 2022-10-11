using System;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveDuration = .5f;
    [SerializeField] private float _rotateDuration = .2f;
    [SerializeField] private float _jumpPower = 0.5f;
    [SerializeField] private float _dieAnimationDuration = 0.5f;
    [SerializeField] private WorldBuilder _worldBuilder;

    private Sequence _moveAnimationSequence;


    void Update()
    {
        if (_moveAnimationSequence == null || !_moveAnimationSequence.IsActive())
        {
            if (Input.GetKey("w"))
            {
                Move(Vector3.forward, new Vector3(0, 0, 0));
            }
            else if (Input.GetKey("s"))
            {
                Move(Vector3.back, new Vector3(0, 180, 0));
            }
            else if (Input.GetKey("a"))
            {
                Move(Vector3.left, new Vector3(0, -90, 0));
            }
            else if (Input.GetKey("d"))
            {
                Move(Vector3.right, new Vector3(0, 90, 0));
            }
        }
    }

    private void Move(Vector3 direction, Vector3 rotation)
    {
        var playerCurrentPosition = transform.position;
        playerCurrentPosition = new Vector3(playerCurrentPosition.x, 0, playerCurrentPosition.z);
        var moveTarget = playerCurrentPosition + direction;

        if (moveTarget.x < _worldBuilder.LeftLimit || moveTarget.x > _worldBuilder.RightLimit)
        {
            MoveBlocked(rotation);
            return;
        }

        if (moveTarget.z < _worldBuilder.ZLimit)
        {
            MoveBlocked(rotation);
            return;
        }


        if (Tree.TreePositions.Contains(moveTarget))
        {
            MoveBlocked(rotation);
            return;
        }

        MoveWithJumpToTargetLocation(rotation, moveTarget);
    }

    private void MoveWithJumpToTargetLocation(Vector3 rotation, Vector3 moveTarget)
    {
        _moveAnimationSequence = transform.DOJump(moveTarget, _jumpPower, 1,
            _moveDuration);
        transform.DORotate(rotation, _rotateDuration);
    }

    private void MoveBlocked(Vector3 rotation)
    {
        // Rotate player to move direction
        transform.DORotate(rotation, _rotateDuration);

        // Sequence for jump animation
        _moveAnimationSequence = DOTween.Sequence();
        _moveAnimationSequence.Append(transform.DOMoveY(_jumpPower, _moveDuration / 2));
        _moveAnimationSequence.Append(transform.DOMoveY(0, _moveDuration / 2));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AnimateDie();
        }
    }

    private void AnimateDie()
    {
        transform.DOScaleY(0.1f, _dieAnimationDuration);
        transform.DOScaleX(2, _dieAnimationDuration);
        transform.DOScaleZ(2, _dieAnimationDuration);
        enabled = false;
    }
}