using Anima2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : PlayerBehaviour, IDamageHandler
{
	public float Energy = 100;

	[SerializeField] List<SpriteMeshInstance> bodySprites;
	[SerializeField] Color hitColor;

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
		//game.SoundManager.PlaySound(SoundManager.ESound.eCitizenDestroy);
		AddEnergy(-pDamage);
		SetColor(hitColor);
		DoInTime(() => SetColor(Color.white), 0.1f);
	}

	private void SetColor(Color pColor)
	{
		foreach(var bs in bodySprites)
		{
			bs.color = pColor;
		}
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
