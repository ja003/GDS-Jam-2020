using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RegionController : GameBehaviour
{
	[SerializeField] GameRegion prefab_Region1;
	[SerializeField] GameRegion prefab_Region2;

	public GameRegion Region;

	Dictionary<EMapItem, List<Vector3>> itemSpawnpoints = new Dictionary<EMapItem, List<Vector3>>();
	List<CitizenSpawnpoint> citizenSpawnpoints = new List<CitizenSpawnpoint>();
	public List<CitizenSpawnpoint> InitialCitizenSpawnpoints = new List<CitizenSpawnpoint>();

	public void Init()
	{
		if(director.RegionIndex == 0)
		{
			game.HUD.Intro.gameObject.SetActive(true);
		}

		if(Region != null)
		{
			Debug.Log("DEBUG: region in scene");
		}
		else
		{
			Debug.Log("TODO: load prefab map " + Director.Instance.RegionIndex);
			Region = Instantiate(prefab_Region1, transform);
		}
		//hack: spawnpoint are not registered yet. wait a few sec
		DoInTime(game.CitizenGenerator.InitialSpawn, 0.5f);
	}


	internal void RegisterItemSpawnpoint(EMapItem pType, Vector3 pPosition)
	{
		if(itemSpawnpoints.ContainsKey(pType))
			itemSpawnpoints[pType].Add(pPosition);
		else
			itemSpawnpoints.Add(pType, new List<Vector3>() { pPosition });

	}

	public Vector3? GetItemSpawnPosition(EMapItem pType)
	{
		List<Vector3> positions = new List<Vector3>();
		itemSpawnpoints.TryGetValue(pType, out positions);
		if(positions != null && positions.Count > 0)
		{
			Vector3 pos = positions[Random.Range(0, positions.Count)];
			//if I dont add random offset the objects stays on top of each other...weird
			pos += new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), 0);
			return pos;
		}

		//Debug.Log($"No position for item {pType} defined");
		return null;
	}


	internal void RegisterCitizenSpawnpoint(CitizenSpawnpoint pSpawnpoint)
	{
		if(pSpawnpoint.IsInitial)
			InitialCitizenSpawnpoints.Add(pSpawnpoint);
		else
			citizenSpawnpoints.Add(pSpawnpoint);
	}

	public Vector3 GetCitizenSpawnPosition()
	{
		Vector3 pos = citizenSpawnpoints[Random.Range(0, citizenSpawnpoints.Count)].transform.position;
		//if I dont add random offset the objects stays on top of each other...weird
		const float offset = 0.5f;
		pos += new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 0);
		return pos;
	}

}
