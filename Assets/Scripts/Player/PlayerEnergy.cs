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
		SetEnergy(Energy - pDamage);
	}

	private void SetEnergy(float pEnergy)
	{
		Energy = pEnergy;
		Debug.Log($"Energy left = {Energy}");
		game.HUD.Energy.energyText.text = $"{Energy}/100!";
	}
}
