using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapItem : GameBehaviour
{
	[SerializeField] SpriteRenderer icon;
	public EMapItem Type;

	internal void Init(EMapItem pType)
	{
		Type = pType;
		icon.sprite = game.ItemManager.GetMapItemIcon(pType);
	}
}
