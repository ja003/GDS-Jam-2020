using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GameBehaviour, IDamageHandler
{
	[SerializeField] public TowerState State;

	[SerializeField] float upgradeTime = 1;
	public const float MAX_UPG_DISTANCE = 1;
	[SerializeField] int spawnOnUpgradeCount = 5;
	[SerializeField] float broadcastRange = 10;
	[SerializeField] float broadcastFrequency = 1;
	[SerializeField] float speedDecrease = 0.2f;

	[SerializeField] bool debug_level1;

	[SerializeField] List<Animator> waveLevels;


	private void Awake()
	{
		State.SetLevel(0);
		if(debug_level1)
			State.SetLevel(1);

		game.EndGame.RegisterTower(this);
	}

	public bool BroadCastEnabled;

	public void Broadcast()
	{
		if(!BroadCastEnabled)
		{
			Debug.Log("stop Broadcast ");
			return;
		}

		//Debug.Log("Broadcast ");
		var citizens = Physics2D.CircleCastAll(transform.position, broadcastRange, Vector2.zero, 0, game.Layers.Citizen);
		foreach(var c in citizens)
		{
			CitizenBrain citizen = c.transform.GetComponent<CitizenBrain>();
			citizen.OnBroadcast(this, speedDecrease);
		}

		for(int i = 0; i < State.Level; i++)
		{
			waveLevels[i].Rebind();
			waveLevels[i].Play("wave");
		}

		DoInTime(Broadcast, broadcastFrequency);
	}

	internal void debug_InstaUpgrade()
	{
		Debug.Log("debug_InstaUpgrade ");
		OnUpgradeComplete(game.Player);
	}

	public void StartUpgrade(Player pWorker)
	{
		if(State.Level == 5)
		{
			//OnUpgradeFailed();
			return;
		}

		pWorker.ThinkBubble.SetReaction(EReaction.Build);

		CheckUpgradeProgress(pWorker);
		game.SoundManager.PlaySound(SoundManager.ESound.eUpgradeStarted);
	}

	public Action OnUpgradeCompleteA;
	//public Action OnUpgradeFail;

	float progress;

	private void CheckUpgradeProgress(Player pPlayer)
	{
		if(Vector2.Distance(transform.position, pPlayer.transform.position) > MAX_UPG_DISTANCE)
		{
			OnUpgradeFailed(pPlayer);
			return;
		}
		pPlayer.ThinkBubble.SetReaction(EReaction.Build);

		const float check_frequency = 0.1f;
		progress += check_frequency;
		Debug.Log("CheckUpgradeProgress " + progress);
		if(progress > upgradeTime)
		{
			OnUpgradeComplete(pPlayer);
			return;
		}

		DoInTime(() => CheckUpgradeProgress(pPlayer), check_frequency);
	}

	private void OnUpgradeComplete(Player pPlayer)
	{
		Debug.Log("Upgrade complete");
		progress = 0;
		State.SetHealth(100);
		State.IncreaseLevel();
		pPlayer?.Inventory.OnTowerUpgraded();
		OnUpgradeCompleteA?.Invoke();
		game.CitizenGenerator.SpawnCitizens(spawnOnUpgradeCount);
		pPlayer.ThinkBubble.SetReaction(EReaction.None);

		game.SoundManager.PlaySound(SoundManager.ESound.eUpgradeDone);
	}

	//private void AddHealth(float pIncrement)
	//{
	//	SetHealth(health + pIncrement);
	//}

	//private void SetHealth(float pHealth)
	//{
	//	health = pHealth;
	//	health = Mathf.Clamp(health, 0, 100);
	//}

	private void OnUpgradeFailed(Player pPlayer)
	{
		Debug.Log("Worker is too far from tower");
		progress = 0;
		//OnUpgradeFail?.Invoke();
		pPlayer.ThinkBubble.SetReaction(EReaction.None);

		game.SoundManager.PlaySound(SoundManager.ESound.eUpgradeFailed);
	}

	private void DoParticleEffect()
	{
		Debug.Log("DoParticleEffect");
	}

	//private void SetLevel(int pLevel)
	//{
	//	Debug.Log("SetLevel " + pLevel);
	//	State.SetLevel(pLevel);
	//	spriteRenderer.sprite = GetLevelImage(pLevel);
	//	if(State.Level == 1)
	//		DoInTime(Broadcast, 1);
	//}


	//private Sprite GetLevelImage(int pLevel)
	//{
	//	switch(pLevel)
	//	{
	//		case 0:
	//			return level0;
	//		case 1:
	//			return level1;
	//		case 2:
	//			return level2;
	//		case 3:
	//			return level3;
	//		case 4:
	//			return level4;
	//		case 5:
	//			return level5;
	//	}
	//	Debug.LogError("Cant get level " + pLevel);
	//	return null;
	//}

	public void OnReceivedDamage(float pDamage)
	{
		State.AddHealth(-pDamage);
	}

	public Vector3 GetPosition()
	{
		return transform.position;
	}
}
