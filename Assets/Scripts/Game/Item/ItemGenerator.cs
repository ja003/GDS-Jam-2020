using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : GameBehaviour
{
	[SerializeField] MapItem mapItemPrefab;
	[SerializeField] bool debug_AlwayGenerate;

	private void Awake()
	{
		DoInTime(GenerateItem, 1);
	}

	private void GenerateItem()
	{
		EMapItem type = EMapItem.GSource;

		foreach(EMapItem item in System.Enum.GetValues(typeof(EMapItem)))
		{
			TryGenerateItem(item);
		}

		
		DoInTime(GenerateItem, 2);
	}

	private void TryGenerateItem(EMapItem pItem)
	{
		Vector3? pos = game.MapController.GetItemSpawnPosition(pItem);

		if(pos == null)
			return;

		//todo: define chance to generate
		if(!debug_AlwayGenerate && Random.Range(0,1f) > 0.5f)
		{
			return;
		}

		//Debug.Log($"Generate item {type} at {pos}");

		MapItem itemInstance = Instantiate(mapItemPrefab, (Vector3)pos, Quaternion.identity);
		itemInstance.transform.parent = transform;
		itemInstance.Init(pItem);
	}
}
