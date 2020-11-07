using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RegionController : MonoBehaviour
{
	[SerializeField] GameRegion prefab_Region1;
	[SerializeField] GameRegion prefab_Region2;


	public GameRegion Region;

    public void Init()
    {
		if(Region != null)
		{
			Debug.Log("DEBUG: region in scene");
			return;
		}
        Debug.Log("TODO: load prefab map " + Director.Instance.RegionIndex);
		Region = Instantiate(prefab_Region1, transform);
    }

	Dictionary<EMapItem, List<Vector3>> itemSpawnpoints = new Dictionary<EMapItem, List<Vector3>>();

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
}
