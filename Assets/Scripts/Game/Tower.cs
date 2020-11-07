﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GameBehaviour
{
	[SerializeField] Sprite level0;
	[SerializeField] Sprite level1;
	[SerializeField] Sprite level2;
	[SerializeField] Sprite level3;
	[SerializeField] Sprite level4;
	[SerializeField] Sprite level5;

	int level;

	[SerializeField] float upgradeTime = 1;
	public const float MAX_UPG_DISTANCE = 1;

	[SerializeField] float broadcastRange = 10;
	[SerializeField] float broadcastFrequency = 1;

	[SerializeField] bool debug_level1;


	private void Awake()
	{
		SetLevel(0);
		if(debug_level1)
			SetLevel(1);
	}

	private void Broadcast()
	{
		Debug.Log("Broadcast ");
		var citizens = Physics2D.CircleCastAll(transform.position, broadcastRange, Vector2.zero, 0, game.Layers.Citizen);
		foreach(var c in citizens)
		{
			CitizenBrain citizen = c.transform.GetComponent<CitizenBrain>();
			citizen.OnBroadcast(this);
		}

		DoInTime(Broadcast, broadcastFrequency);
	}

	public void StartUpgrade(Player pWorker)
	{
		CheckUpgradeProgress(pWorker);
	}

	public Action OnUpgradeSuccess;
	public Action OnUpgradeFail;

	float progress;

	private void CheckUpgradeProgress(Player pWorker)
	{
		if(Vector2.Distance(transform.position, pWorker.transform.position) > MAX_UPG_DISTANCE)
		{
			Debug.Log("Worker is too far from tower");
			progress = 0;
			OnUpgradeFail?.Invoke();
			return;
		}

		const float check_frequency = 0.1f;
		progress += check_frequency;
		Debug.Log("CheckUpgradeProgress " + progress);
		if(progress > upgradeTime)
		{
			Debug.Log("Upgrade complete");
			progress = 0;
			SetLevel(level + 1);
			pWorker.Inventory.OnTowerUpgraded();
			OnUpgradeSuccess?.Invoke();
			return;
		}

		DoInTime(() => CheckUpgradeProgress(pWorker), check_frequency);
	}

	//public void Upgrade()
	//{
	//	Debug.Log("Upgrade");
	//	DoParticleEffect();
	//	DoInTime(() => SetLevel(level + 1), upgradeTime);
	//}

	private void DoParticleEffect()
	{
		Debug.Log("DoParticleEffect");
	}

	private void SetLevel(int pLevel)
	{
		Debug.Log("SetLevel " + pLevel);
		level = pLevel;
		spriteRend.sprite = GetLevelImage(pLevel);
		if(level == 1)
			DoInTime(Broadcast, 1);
	}


	private Sprite GetLevelImage(int pLevel)
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
}
