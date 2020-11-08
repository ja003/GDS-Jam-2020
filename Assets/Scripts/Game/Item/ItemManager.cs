using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : GameBehaviour
{
	[SerializeField] Sprite mapIcon_gSource;
	[SerializeField] Sprite mapIcon_TrueNews;

	[SerializeField] public TrueNews prefab_TrueNews;


	public Sprite GetMapItemIcon(EMapItem pType)
	{
		switch(pType)
		{
			case EMapItem.None:
				break;
			case EMapItem.GSource:
				return mapIcon_gSource;
			case EMapItem.TrueNews:
				return mapIcon_TrueNews;
			case EMapItem.TinFoilHat:
				break;
			default:
				break;
		}
		return null;
	}

	public bool UseItem(Player pPlayer, EMapItem pType)
	{
		switch(pType)
		{
			case EMapItem.None:
				break;
			case EMapItem.GSource:
				var hit = Physics2D.CircleCast(pPlayer.transform.position, Tower.MAX_UPG_DISTANCE, Vector2.zero, 0, game.Layers.Tower);
				if(hit)
				{
					hit.transform.gameObject.GetComponent<Tower>().StartUpgrade(pPlayer);
				}
				else
				{
					Debug.Log("No tower near");
					return false;
				}
				return true;

			case EMapItem.TrueNews:
				TrueNews trueNewsInstance = Instantiate(prefab_TrueNews);
				trueNewsInstance.transform.parent = transform;
				trueNewsInstance.Throw(pPlayer);
				pPlayer.Inventory.RemoveItem(pType);
				return true;
				

			case EMapItem.TinFoilHat:
				if(pPlayer.TinFoilHat.IsActive)
				{
					Debug.Log("Tinfoil hat is already active");
					return false;
				}
				pPlayer.TinFoilHat.Activate();
				pPlayer.Inventory.RemoveItem(pType);
				return true;
		}

		return false;
	}
}
