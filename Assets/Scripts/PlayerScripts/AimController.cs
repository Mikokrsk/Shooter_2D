using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;

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
            var bullet = Instantiate(_bulletPref, transform);

            bullet.transform.parent = null;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = mousePosition - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        }
    }
}