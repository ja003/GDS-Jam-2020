using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : CSingleton<Game>
{
    [SerializeField] public RegionController MapController;
    [SerializeField] public ItemManager ItemManager;
    [SerializeField] public Layers Layers;
	[SerializeField] public Player Player;

    [SerializeField] public HudController HUD;

    protected new void Awake()
    {
        base.Awake();
        MapController.Init();
    }
}
