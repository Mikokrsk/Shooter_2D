using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireMode : FireMode
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (_currentFireRate > 0)
        {
            _currentFireRate -= Time.deltaTime;
        }
    }
}