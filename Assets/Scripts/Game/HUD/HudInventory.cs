using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudInventory : MonoBehaviour
{
    [SerializeField] List<Image> itemIcons;

    internal void OnItemCountChanged(EMapItem pItem, int pCount)
    {
        GetItemSprite(pItem).color = new Color(1, 1, 1, pCount > 0 ? 1 : 0.5f);
    }

    private Image GetItemSprite(EMapItem pItem)
    {
        return itemIcons[(int)pItem - 1];
    }
}
