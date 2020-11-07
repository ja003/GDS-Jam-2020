using System;
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

	private void Awake()
	{
		SetLevel(0);
	}

	public void StartUpgrade(Transform pWorker)
	{
		CheckUpgradeProgress(pWorker);
	}

	public Action OnUpgradeSuccess;
	public Action OnUpgradeFail;

	float progress;

	private void CheckUpgradeProgress(Transform pWorker)
	{
		if(Vector2.Distance(transform.position, pWorker.position) > MAX_UPG_DISTANCE)
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
