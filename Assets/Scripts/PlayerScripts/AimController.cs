using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Gun _gun;

    private void Update()
    {
        Shoot();
        RotateWithCursore();
    }


    private void RotateWithCursore()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gun?.Fire();
        }
    }
}