using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Fire()
    {
        base.Fire();
        Debug.Log($"Fire {this.name}");
    }
}