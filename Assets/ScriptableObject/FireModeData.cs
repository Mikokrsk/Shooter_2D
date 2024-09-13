using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireModeData", menuName = "ScriptableObjects/FireModeData", order = 1)]
public class FireModeData : ScriptableObject
{
    [Header("FireMode Stats")]
    public float fireRateMax = 0.1f;

    public float bulletSpread = 0.1f;
}