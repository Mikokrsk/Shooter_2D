using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireMode : FireMode
{
    private void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButton(0))
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