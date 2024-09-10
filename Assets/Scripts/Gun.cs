using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletSpawnPosition;

    public virtual void Fire()
    {
        var bullet = Instantiate(_bulletPref, _bulletSpawnPosition.transform.position, transform.rotation, transform);

        bullet.transform.parent = null;
    }
}