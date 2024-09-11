using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireMode : FireMode
{
    private void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            if (currentFireRate > 0)
            {
                currentFireRate -= Time.deltaTime;
            }
        }
    }
}