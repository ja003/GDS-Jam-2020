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

    internal void OnUseItem(int pIndex, bool pUseResult)
    {
        Debug.Log($"TODO: Play OnUseItem sound {pUseResult}" + itemIcons[pIndex].name);
        Animator animator = itemIcons[pIndex].GetComponent<Animator>();
        animator.Rebind();
        animator.Play(pUseResult ? "useOK" : "useFail");
    }
}
