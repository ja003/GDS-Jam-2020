using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TextureSortingController : GameBehaviour
{
	private SortingGroup sortingGroup;

	[SerializeField]
	private float offset = 0.0f;

	// Update is called once per frame
	void Update()
    {
		if(sortingGroup == null)
			sortingGroup = GetComponent<SortingGroup>();

		if (gameObject.transform.position.y + offset < game.Player.gameObject.transform.position.y)
			sortingGroup.sortingOrder = 100;
		else
			sortingGroup.sortingOrder = 1;
	}
}
