using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PlayerBehaviour
{
	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		player.Movement.Move(h, v);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			player.Inventory.UseItem(player, 0);
		}
	}
}
