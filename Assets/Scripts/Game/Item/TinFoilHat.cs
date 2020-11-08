using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinFoilHat : GameBehaviour
{
    [SerializeField] float duration = 5;
	[SerializeField] private GameObject regularHat;
	public bool IsActive;
	

    private void Awake()
    {
        Deactivate();
    }

    public void Activate()
    {
		regularHat.SetActive(false);

		skinMeshRend.enabled = true;
        IsActive = true;
        DoInTime(Deactivate, duration);
    }

    private void Deactivate()
    {
		skinMeshRend.enabled = false;
        IsActive = false;

		regularHat.SetActive(true);
	}
}
