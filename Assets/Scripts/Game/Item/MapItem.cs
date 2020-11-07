using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapItem : GameBehaviour
{
	[SerializeField] SpriteRenderer icon;

	internal void Init(EMapItem pType)
	{
		icon.sprite = game.ItemManager.GetMapItemIcon(pType);
	}
}
