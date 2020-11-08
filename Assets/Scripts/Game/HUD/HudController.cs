using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] public HudInventory Inventory;
    [SerializeField] public HudEnergy Energy;
    [SerializeField] public Curtain Curtain;
    [SerializeField] public IntroController Intro;
    [SerializeField] public TrueNewsPopup TrueNewsPopup;
    [SerializeField] public EndScreen EndScreen;

    [SerializeField] public Canvas Canvas;
}
