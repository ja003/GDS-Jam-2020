using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PlayerBehaviour
{
	private void FixedUpdate()
	{
		if(!IsInputEnabled())
			return;

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		player.Movement.Move(h, v);
	}

	private bool IsInputEnabled()
	{
		return player.Energy.Energy > 1 && !game.EndGame.GameEnded;
	}

	private void Update()
	{
		if(!IsInputEnabled())
			return;

		if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.E))
		{
			player.Inventory.UseItem(player, 1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			player.Inventory.UseItem(player, 2);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			player.Inventory.UseItem(player, 3);
		}
	}
}
