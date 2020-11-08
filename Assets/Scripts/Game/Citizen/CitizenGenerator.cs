using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenGenerator : GameBehaviour
{
	[SerializeField] GameObject prefab_Citizen;

	[SerializeField] float spawnFrequency = 15;

	private void Awake()
	{
		DoInTime(PeriodicalSpawn, spawnFrequency);
	}

	private void PeriodicalSpawn()
	{
		Debug.Log("PeriodicalSpawn");
		SpawnCitizen();
		DoInTime(PeriodicalSpawn, spawnFrequency);
	}

	public void InitialSpawn()
	{
		Debug.Log("InitialSpawn");
		foreach(CitizenSpawnpoint spawnpoint in game.MapController.InitialCitizenSpawnpoints)
		{
			SpawnCitizens(spawnpoint.Count, spawnpoint.transform.position);
		}
	}

	public void SpawnCitizen(Vector3? pPos = null)
	{
		Vector3 pos = pPos != null ? (Vector3)pPos : game.MapController.GetCitizenSpawnPosition();
		var citizenInstance = Instantiate(prefab_Citizen, transform);
		citizenInstance.transform.position = pos;
	}

	internal void SpawnCitizens(int pCount, Vector3? pPos = null)
	{
		StartCoroutine(SpawnCitizensC(pCount, pPos));
	}

	private IEnumerator SpawnCitizensC(int pCount, Vector3? pPos = null)
	{
		for(int i = 0; i < pCount; i++)
		{
			SpawnCitizen(pPos);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
