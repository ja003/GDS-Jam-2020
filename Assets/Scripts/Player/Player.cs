using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private void OnTriggerStay2D(Collider2D pCollision)
	{
		if (pCollision.tag == "Collectable")
		{
			Destroy(pCollision.gameObject);
		}


		if (pCollision.tag == "Tower")
		{
			Tower tower = pCollision.GetComponent<Tower>();
		}

	}
}
