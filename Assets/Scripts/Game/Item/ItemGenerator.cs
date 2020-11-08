using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : GameBehaviour
{
	[SerializeField] MapItem mapItemPrefab;
	[SerializeField] bool debug_AlwayGenerate;
	[SerializeField] float generateFrequency = 5;

	private void Awake()
	{
		DoInTime(() => TryGenerateItem(EMapItem.GSource, true), 2);
		DoInTime(GenerateItem, 1);
	}

	private void GenerateItem()
	{
		foreach(EMapItem item in System.Enum.GetValues(typeof(EMapItem)))
		{
			TryGenerateItem(item);
		}


		DoInTime(GenerateItem, generateFrequency);
	}

	Dictionary<EMapItem, MapItem> lastGenerated = new Dictionary<EMapItem, MapItem>();

	private void TryGenerateItem(EMapItem pItem, bool pForce = false)
	{
		Vector3? pos = game.MapController.GetItemSpawnPosition(pItem);

		if(pos == null)
			return;

		if(!lastGenerated.ContainsKey(pItem) || (lastGenerated.ContainsKey(pItem) && lastGenerated[pItem] == null))
			pForce = true;

		//todo: define chance to generate
		if(!debug_AlwayGenerate && !pForce && Random.Range(0, 1f) > 0.5f)
		{
			return;
		}

		

		//Debug.Log($"Generate item {type} at {pos}");

		MapItem itemInstance = Instantiate(mapItemPrefab, (Vector3)pos, Quaternion.identity);
		itemInstance.transform.parent = transform;
		itemInstance.Init(pItem);

		if(lastGenerated.ContainsKey(pItem))
			lastGenerated[pItem] = itemInstance;
		else
			lastGenerated.Add(pItem, itemInstance);
	}
}
