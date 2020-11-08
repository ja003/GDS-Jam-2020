using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeShop : GameBehaviour
{
	[SerializeField] CircleCollider2D healArea;
	[SerializeField] float healFrequency = 1;
	[SerializeField] float healAmount = 5;

	private void Awake()
	{
		TryHeal();
	}

	private void TryHeal()
	{
		var playerHit = Physics2D.CircleCast(healArea.bounds.center, healArea.radius, Vector2.zero, 0, game.Layers.Player);
		if (playerHit)
		{
			Player player = playerHit.transform.GetComponent<Player>();
			PlayerEnergy playerEnergy = player.Energy;
			playerEnergy.AddEnergy(healAmount);
			Debug.Log("Heal player " + healAmount);
			player.ThinkBubble.SetReaction(EReaction.Coffee, 0.5f);
			Game.Instance.SoundManager.PlaySound(SoundManager.ESound.eCoffee);
		}
		else
		{
			Game.Instance.SoundManager.StopSound(SoundManager.ESound.eCoffee);
		}

		DoInTime(TryHeal, healFrequency);
	}
}
