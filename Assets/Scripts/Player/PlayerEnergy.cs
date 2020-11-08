using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : PlayerBehaviour, IDamageHandler
{
	public float Energy = 100;

	private void Awake()
	{
		SetEnergy(100);
	}

	public Vector3 GetPosition()
	{
		return transform.position;
	}

	public void OnReceivedDamage(float pDamage)
	{
		AddEnergy(-pDamage);
	}

	private void SetEnergy(float pEnergy)
	{
		Energy = pEnergy;
		Energy = Mathf.Clamp(Energy, 0, 100);
		Debug.Log($"Energy left = {Energy}");
		//game.HUD.Energy.energyText.text = $"{Energy}/100!";
		game.HUD.Energy.NumOfHp = Energy * 0.1f;

		if(Energy < 1)
		{
			game.EndGame.EndGame(false);
		}
	}

	internal void AddEnergy(float pIncrement)
	{
		SetEnergy(Energy + pIncrement);
	}
}
