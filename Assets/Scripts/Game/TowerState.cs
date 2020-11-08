using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerState : GameBehaviour
{
	[SerializeField] Tower tower;

	[SerializeField] SpriteRenderer towerSR;
	[SerializeField] Sprite towerLevel0;
	[SerializeField] Sprite towerLevel1;
	[SerializeField] Sprite towerLevel2;
	[SerializeField] Sprite towerLevel3;
	[SerializeField] Sprite towerLevel4;
	[SerializeField] Sprite towerLevel5;

	[SerializeField] SpriteRenderer levelSR;
	[SerializeField] Sprite level0;
	[SerializeField] Sprite level1;
	[SerializeField] Sprite level2;
	[SerializeField] Sprite level3;
	[SerializeField] Sprite level4;
	[SerializeField] Sprite level5;


	[SerializeField] SpriteRenderer bar1;
	[SerializeField] SpriteRenderer bar2;
	[SerializeField] SpriteRenderer bar3;
	[SerializeField] SpriteRenderer bar4;
	[SerializeField] SpriteRenderer bar5;

	public int Level;
	public float health = 100;

	public void SetHealth(float pHealth)
	{
		pHealth = Mathf.Clamp(pHealth, 0, 100);
		health = pHealth;

		bar1.color = new Color(1, 1, 1, GetAlpha(health, 10));
		bar2.color = new Color(1, 1, 1, GetAlpha(health, 40));
		bar3.color = new Color(1, 1, 1, GetAlpha(health, 60));
		bar4.color = new Color(1, 1, 1, GetAlpha(health, 80));
		bar5.color = new Color(1, 1, 1, GetAlpha(health, 90));

		if(health <= 0)
		{
			SetLevel(Level - 1);
		}
	}

	private static float GetAlpha(float pHealth, float pMinValue)
	{
		return pHealth > pMinValue ? 1 : 0.5f;
	}

	internal void AddHealth(float pIncrement)
	{
		SetHealth(health + pIncrement);
	}

	internal void SetLevel(int pLevel)
	{
		pLevel = Mathf.Clamp(pLevel, 0, 5);
		Level = pLevel;
		Debug.Log("SetLevel " + pLevel);
		towerSR.sprite = GetTowerSprite(Level);
		levelSR.sprite = GetLevelSprite(Level);

		tower.BroadCastEnabled = Level > 0;
		if(Level == 1)
			DoInTime(tower.Broadcast, 1);
	}

	private Sprite GetTowerSprite(int pLevel)
	{
		switch(pLevel)
		{
			case 0:
				return towerLevel0;
			case 1:
				return towerLevel1;
			case 2:
				return towerLevel2;
			case 3:
				return towerLevel3;
			case 4:
				return towerLevel4;
			case 5:
				return towerLevel5;
		}
		Debug.LogError("Cant get level " + pLevel);
		return null;
	}

	private Sprite GetLevelSprite(int pLevel)
	{
		switch(pLevel)
		{
			case 0:
				return level0;
			case 1:
				return level1;
			case 2:
				return level2;
			case 3:
				return level3;
			case 4:
				return level4;
			case 5:
				return level5;
		}
		Debug.LogError("Cant get level " + pLevel);
		return null;
	}

	internal void IncreaseLevel()
	{
		SetLevel(Level + 1);
	}
}
