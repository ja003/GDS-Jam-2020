using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Sprite gSourceMapIcon;


    public Sprite GetMapItemIcon(EMapItem pType)
    {
        switch(pType)
        {
            case EMapItem.None:
                break;
            case EMapItem.GSource:
                return gSourceMapIcon;
            case EMapItem.TinFoilHat:
                break;
            default:
                break;
        }
        return null;
    }
}
