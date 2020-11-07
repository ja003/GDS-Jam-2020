using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRegion : MonoBehaviour
{
    [SerializeField] List<RegionZone> zones;

	[SerializeField] public BoxCollider2D MapBounds;
}
