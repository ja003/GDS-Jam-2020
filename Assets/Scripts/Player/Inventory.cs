using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : GameBehaviour
{
	private const int ITEM_COUNT = 10;
	Dictionary<EMapItem, int> itemsCount = new Dictionary<EMapItem, int>();
	//Dictionary<EMapItem, int> itemsIndexes = new Dictionary<EMapItem, int>();
	//EMapItem[] items;

	[SerializeField] bool debug_StartupItems;

	private void Awake()
	{
		//items = new EMapItem[ITEM_COUNT];
		//for(int i = 0; i < ITEM_COUNT; i++)
		//{
		//	items[i] = EMapItem.None;
		//}

		//fixed positions
		AddItem(EMapItem.GSource, 0);
		AddItem(EMapItem.TrueNews, 0);
		AddItem(EMapItem.TinFoilHat, 0);

		if(debug_StartupItems)
		{
			AddItem(EMapItem.GSource, 3);
			AddItem(EMapItem.TrueNews, 3);
			AddItem(EMapItem.TinFoilHat, 3);
		}
	}

	public bool AddItem(EMapItem pItem, int pCount = 1)
	{
		if(pCount > 0 && !itemsCount.ContainsKey(pItem))
		{
			Debug.LogError($"Item {pItem} not in inventory");
			return false;
		}

		//we can only carry 1 G
		if(pItem == EMapItem.GSource)
		{
			itemsCount.TryGetValue(pItem, out int count);
			if(count > 0)
				return false;
		}

		if(itemsCount.ContainsKey(pItem))
		{
			itemsCount[pItem] += pCount;
		}
		else
		{
			//items[itemsCount.Values.Count] = pItem;
			itemsCount.Add(pItem, pCount);
		}

		Game.Instance.SoundManager.PlaySound(SoundManager.ESound.eCollect);

		game.HUD.Inventory.OnItemCountChanged(pItem, itemsCount[pItem]);

		return true;
	}

	public void RemoveItem(EMapItem pItem)
	{
		Debug.Log("RemoveItem " + pItem);
		if(!itemsCount.ContainsKey(pItem))
		{
			Debug.LogError($"Item {pItem} not in inventory");
			return;
		}
		if(itemsCount[pItem] <= 0)
		{
			Debug.LogError($"Item {pItem} has 0 count");
			return;
		}

		itemsCount[pItem] -= 1;
		game.HUD.Inventory.OnItemCountChanged(pItem, itemsCount[pItem]);
	}

	public bool UseItem(Player pPlayer, int pIndex)
	{
		itemsCount.TryGetValue((EMapItem)pIndex, out int count);
		int indexInHud = pIndex - 1;
		if(count == 0)
		{
			Debug.Log("Cant use item " + (EMapItem)pIndex);
			game.HUD.Inventory.OnUseItem(indexInHud, false);
			return false;
		}

		bool useResult = game.ItemManager.UseItem(pPlayer, (EMapItem)pIndex);
		game.HUD.Inventory.OnUseItem(indexInHud, useResult);
		return useResult;

	}

	internal void OnTowerUpgraded()
	{
		RemoveItem(EMapItem.GSource);
	}

	internal bool HasItem(EMapItem pItem)
	{
		return itemsCount[pItem] > 0;
	}
}
