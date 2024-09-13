using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireMode : FireMode
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (_currentFireRate > 0)
        {
            _currentFireRate -= Time.deltaTime;
        }
    }
}