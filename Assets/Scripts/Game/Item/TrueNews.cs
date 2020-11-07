using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueNews : GameBehaviour
{
	[SerializeField] Transform newspaper;

	internal void Throw(Player pPlayer)
	{
		transform.position = pPlayer.ItemSpawnPos.position;
	}

	public Vector3 GetPosition()
	{
		return newspaper.transform.position;
	}
}
