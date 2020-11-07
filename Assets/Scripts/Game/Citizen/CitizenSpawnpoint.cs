using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSpawnpoint : GameBehaviour
{
	public bool IsInitial;
	public int Count;

	private void Awake()
	{
		game.MapController.RegisterCitizenSpawnpoint(this);
	}
}
