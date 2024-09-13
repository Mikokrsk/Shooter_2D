using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireMode : MonoBehaviour
{
    [SerializeField] protected FireModeData _settings;

    [SerializeField] protected Firearm firearm;

    protected float _currentFireRate = 0.1f;

    protected virtual void Start()
    {
        if (firearm == null)
        {
            firearm = GetComponent<Firearm>();
        }
    }

    protected virtual void Shoot()
    {
        if (firearm.isReloading) return;

        if (_currentFireRate <= 0)
        {
            _currentFireRate = _settings.fireRateMax;
            firearm.SpawnBullet(GetRandomBulletSpread());
        }
    }

    protected virtual float GetRandomBulletSpread()
    {
        var bulletSpread = Random.Range(-_settings.bulletSpread, _settings.bulletSpread);
        return bulletSpread;
    }

}