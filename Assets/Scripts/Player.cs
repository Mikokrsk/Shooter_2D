using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private BoxCollider2D _bounds;

    [SerializeField] private GameObject _bulletPref;

    private void Awake()
    {
        if (_speed < 0)
        {
            _speed = 1;
        }
    }

    private void Update()
    {
        HandleMovement();
        RotateWithCursore();
        Shoot();
    }

    private void HandleMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            transform.position = new Vector3(transform.position.x + horizontal * Time.deltaTime * _speed, transform.position.y + vertical * Time.deltaTime * _speed);
            BoundsCheck();

        }
    }

    private void RotateWithCursore()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void BoundsCheck()
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
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_bulletPref, transform);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = mousePosition - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        }
    }
}