using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] public Inventory Inventory;
	[SerializeField] public PlayerMovement Movement;
	[SerializeField] public PlayerEnergy Energy;

	[SerializeField] public Transform ItemSpawnPos;
	[SerializeField] public TinFoilHat TinFoilHat;

	[SerializeField] public ThinkBubble ThinkBubble;


	[SerializeField] public float ThrowForce = 5;

	private void OnTriggerStay2D(Collider2D pCollision)
	{
		if (pCollision.tag == "Collectable")
		{
			MapItem item = pCollision.gameObject.GetComponent<MapItem>();

			if(Inventory.AddItem(item.Type))
				Destroy(item.gameObject);
		}


		if (pCollision.tag == "Tower")
		{
			Tower tower = pCollision.GetComponent<Tower>();
		}

	}
}
