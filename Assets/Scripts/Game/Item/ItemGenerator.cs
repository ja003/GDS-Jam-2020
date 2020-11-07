using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : GameBehaviour
{
	[SerializeField] MapItem mapItemPrefab;

	private void Awake()
	{
		DoInTime(GenerateItem, 1);
	}

	private void GenerateItem()
	{
		EMapItem type = EMapItem.GSource;
		Vector3 pos = game.MapController.GetItemSpawnPosition(type);

		Debug.Log($"Generate item {type} at {pos}");

		MapItem itemInstance = Instantiate(mapItemPrefab, pos, Quaternion.identity);
		itemInstance.transform.parent = transform;
		itemInstance.Init(type);
		DoInTime(GenerateItem, 2);
	}
}
