using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    void Update()
    {
        var newPosition = transform.right * _speed * Time.deltaTime;
        transform.position += newPosition;
    }
}