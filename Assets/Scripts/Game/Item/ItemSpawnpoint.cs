using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnpoint : GameBehaviour
{
    [SerializeField] EMapItem type;

    private void Awake()
    {
        game.MapController.RegisterItemSpawnpoint(type, transform.position);
    }
}
