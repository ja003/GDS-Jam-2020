using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : CSingleton<Game>
{
    [SerializeField] public RegionController MapController;
    [SerializeField] public ItemManager ItemManager;

    protected new void Awake()
    {
        base.Awake();
        MapController.Init();
    }
}
