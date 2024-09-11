using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Firearm : Weapon
{
    [SerializeField] protected List<FireMode> _fireModeList;
    [SerializeField] protected int _currentFireModeId;

    protected virtual void Awake()
    {
        if (_currentFireModeId < 0 || _currentFireModeId >= _fireModeList.Count)
        {
            _currentFireModeId = 0;
        }
        _fireModeList[_currentFireModeId].isActive = true;
    }

    private void Update()
    {
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
            fireMode.isActive = false;
        }
        _fireModeList[_currentFireModeId].isActive = true;
    }
}