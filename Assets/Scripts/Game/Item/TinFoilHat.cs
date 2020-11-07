using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinFoilHat : GameBehaviour
{
    [SerializeField] float duration = 5;
    public bool IsActive;

    private void Awake()
    {
        Deactivate();
    }

    public void Activate()
    {
        spriteRend.enabled = true;
        IsActive = true;
        DoInTime(Deactivate, duration);
    }

    private void Deactivate()
    {
        spriteRend.enabled = false;
        IsActive = false;
    }
}
