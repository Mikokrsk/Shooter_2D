using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class PlayerHandleMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Transform _playerPosition;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            var direction = new Vector3(horizontal, vertical).normalized;
            var newPosition = direction * _speed * Time.deltaTime;
            _playerPosition.transform.position += newPosition;
        }
    }
    /*    private void BoundsCheck()
        {
            if (transform.position.x > _bounds.bounds.max.x)
            {
                transform.position = new Vector3(_bounds.bounds.max.x, transform.position.y);
            }
            if (transform.position.x < _bounds.bounds.min.x)
            {
                transform.position = new Vector3(_bounds.bounds.min.x, transform.position.y);
            }
            if (transform.position.y > _bounds.bounds.max.y)
            {
                transform.position = new Vector3(transform.position.x, _bounds.bounds.max.y);
            }
            if (transform.position.y < _bounds.bounds.min.y)
            {
                transform.position = new Vector3(transform.position.x, _bounds.bounds.min.y);
            }
        }*/
}