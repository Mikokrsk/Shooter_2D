using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private float _curShootingDelay;
    [SerializeField] private bool _isShooting;

    protected virtual void Update()
    {
        if (_curShootingDelay >= 0 && !_isShooting)
        {
            _isShooting = false;
            _curShootingDelay -= Time.deltaTime;
        }
        else
        {
            _isShooting = true;
            _curShootingDelay = _shootingDelay;
        }
    }

    public virtual void Fire()
    {
        if (_isShooting)
        {
            SpawnBullet();
            _isShooting = false;
        }
    }

    private void SpawnBullet()
    {
        Instantiate(_bulletPref, _bulletSpawnPosition.transform.position, transform.rotation, null);
    }
}