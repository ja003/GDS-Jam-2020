using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : GameBehaviour
{
	[SerializeField] Sprite mapIcon_gSource;
	[SerializeField] Sprite mapIcon_TrueNews;


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

	public void UseItem(Player pPlayer, EMapItem pType)
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
				}

				break;
			case EMapItem.TinFoilHat:
				break;
		}
	}
}
