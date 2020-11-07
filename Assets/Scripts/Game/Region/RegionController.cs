using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionController : MonoBehaviour
{
    public void Init()
    {
        Debug.Log("TODO: load prefab map " + Director.Instance.RegionIndex);
    }

	Dictionary<EMapItem, List<Vector3>> itemSpawnpoints = new Dictionary<EMapItem, List<Vector3>>();

	internal void RegisterItemSpawnpoint(EMapItem pType, Vector3 pPosition)
	{
		if(itemSpawnpoints.ContainsKey(pType))
			itemSpawnpoints[pType].Add(pPosition);
		else
			itemSpawnpoints.Add(pType, new List<Vector3>() { pPosition });

	}

	public Vector3 GetItemSpawnPosition(EMapItem pType)
	{
		List<Vector3> positions = new List<Vector3>();
		itemSpawnpoints.TryGetValue(pType, out positions);
		if(positions != null && positions.Count > 0)
			return positions[UnityEngine.Random.Range(0, positions.Count)];

		Debug.LogError($"No posiiton for item {pType} defined");
		return Vector3.zero;
	}
}
