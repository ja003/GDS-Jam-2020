using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueNews : GameBehaviour
{
	[SerializeField] int duration = 5;
	[SerializeField] Transform newspaper;

	internal void Throw(Player pPlayer)
	{
		transform.position = pPlayer.ItemSpawnPos.position;
		DoInTime(() => Destroy(gameObject), duration);

		game.HUD.TrueNewsPopup.OnThrow(this);
	}

	public Vector3 GetPosition()
	{
		return newspaper.transform.position;
	}
}
