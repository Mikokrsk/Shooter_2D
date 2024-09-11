using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireMode : MonoBehaviour
{
    public bool isActive;

    [SerializeField] protected GameObject bulletPref;
    [SerializeField] protected Transform bulletSpawnPosition;

    [SerializeField] protected float fireRateMax = 0.1f;
    [SerializeField] protected int magazineCapacity = 30;
    [SerializeField] protected float reloadTime = 2.0f;

    [SerializeField] protected float currentFireRate = 0.1f;
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected bool isReloading = false;

    protected virtual void Start()
    {
        currentAmmo = magazineCapacity;
    }

    protected virtual void Shoot()
    {
        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (isReloading) return;

        if (currentFireRate <= 0)
        {
            SpawnBullet();
            currentAmmo--;
            currentFireRate = fireRateMax;
        }

    }

    protected virtual void SpawnBullet()
    {
        Instantiate(bulletPref, bulletSpawnPosition.position, transform.rotation, null);
    }

    protected virtual IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineCapacity;
        isReloading = false;
        Debug.Log("Reloaded.");
    }
}