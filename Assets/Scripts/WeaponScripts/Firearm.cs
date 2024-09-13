using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Firearm : Weapon
{
    [Header("Bullet Settings")]
    public GameObject bulletPref;
    public Transform bulletSpawnPosition;

    [Header("Weapon Settings")]
    public int magazineCapacity = 30;
    public float reloadTime = 2.0f;

    [SerializeField] protected List<FireMode> _fireModeList;
    [SerializeField] protected int _currentFireModeId;
    [field: SerializeField] public int currentAmmo { get; private set; }
    [field: SerializeField] public bool isReloading { get; private set; }

    protected virtual void Awake()
    {
        if (_currentFireModeId < 0 || _currentFireModeId >= _fireModeList.Count)
        {
            _currentFireModeId = 0;
        }

        foreach (var fireMode in _fireModeList)
        {
            fireMode.enabled = false;
        }
        _fireModeList[_currentFireModeId].enabled = true;
        currentAmmo = magazineCapacity;
    }

    private void Update()
    {
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchFireMode();
        }
    }

    public void SwitchFireMode()
    {
        if (_currentFireModeId + 1 >= _fireModeList.Count)
        {
            _currentFireModeId = 0;
        }
        else
        {
            _currentFireModeId++;
        }

        foreach (var fireMode in _fireModeList)
        {
            fireMode.enabled = false;
        }
        _fireModeList[_currentFireModeId].enabled = true;
    }

    public virtual void SpawnBullet(float bulletSpread)
    {
        var rotation = transform.rotation;
        var rotationEuler = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + bulletSpread);
        rotation.eulerAngles = rotationEuler;

        Instantiate(bulletPref, bulletSpawnPosition.position, rotation, null);

        currentAmmo--;
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
