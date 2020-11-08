using Anima2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitizenBrain : GameBehaviour
{
	[SerializeField] PlayerMovement movement;
	[SerializeField] IDamageHandler attackTarget;
	[SerializeField] Vector3? targetPos;

	[SerializeField] float sightRange = 5;
	[SerializeField] float attackRange = 1;
	[SerializeField] float damage = 5;

	[SerializeField] float timeToForgetBroadcast = 5;


	[SerializeField] Transform debug_target;
	[SerializeField] bool debug_idle;

	[SerializeField] ThinkBubble bubble;

	protected const float REACH_DIST_TOLLERANCE = 0.3f;
	[SerializeField] float MIN_SPEED = 0.5f;
	[SerializeField] float MAX_SPEED = 3f;
	[SerializeField] float REGEN_FREQUENCY = 10f;
	[SerializeField] float REGEN_AMOUNT = 0.2f;
	bool idle;
	bool attack;

	[SerializeField] List<SpriteMeshInstance> bodySprites;
	[SerializeField] Color hitColor;


	private void Update()
	{
		//if(debug_target)
		//	attackTarget = debug_target;
		if(attackTarget != null)
			targetPos = attackTarget.GetPosition();
		if(targetPos == null)
		{
			movement.Move(0, 0);
			return;
		}

		Vector3 targetPosition = (Vector3)targetPos;
		Utils.DebugDrawCross(targetPosition, Color.red);

		Vector3 dir = (targetPosition - transform.position).normalized;
		
		float dist = GetDistanceTo(targetPosition);
		if(attack && dist < attackRange - DIST_OFFSET)
			idle = true;
		if(dist < REACH_DIST_TOLLERANCE)
			idle = true;

		if(idle)
		{
			Idle();
			return;
		}

		//Debug.Log($"Move {dir} | dist = {dist}");
		movement.Move(dir.x, dir.y);
	}

	[SerializeField] float evaluateFrequency = 1;

	private void Awake()
	{
		DoInTime(Evaluate, evaluateFrequency);

		DoInTime(Regenerate, REGEN_FREQUENCY);
	}

	private void Regenerate()
	{
		AddSpeed(REGEN_AMOUNT);
		DoInTime(Regenerate, REGEN_FREQUENCY);
	}

	private void Evaluate()
	{
		//Debug.Log("Evaluate ");

		attackTarget = null;
		targetPos = null;
		attack = false;
		idle = false;

		if(debug_idle)
			Idle();


		var playerHit = Physics2D.CircleCast(transform.position, sightRange, Vector2.zero, 0, game.Layers.Player);
		//todo: only if he has G

		EReaction reaction = EReaction.None;
		if(CheckTrueNews())
		{
			reaction = EReaction.What;
		}
		else if(CheckPlayer())
		{
			reaction = EReaction.Trigger;
		}
		else if(WasBrodcastedRecently())
		{
			attackTarget = lastTowerNoticed;
			reaction = EReaction.Trigger;
			attack = true;
		}
		else
		{
			if(Random.Range(0, 1f) > 0.5f)
			{
				Idle();
				//todo: he doesnt stop
				//Debug.Log("Idle");
			}
			else
			{
				float ranomX = Random.Range(-attackRange * 2, attackRange * 2);
				float ranomY = Random.Range(-attackRange * 2, attackRange * 2);
				targetPos = transform.position + new Vector3(ranomX, ranomY, 0);
				//Debug.Log("Mingle");
			}
		}

		if(attack && attackTarget != null && GetDistanceTo(attackTarget.GetPosition()) < attackRange)
		{
			Attack(attackTarget);
		}

		bubble.SetReaction(reaction);

		if (reaction == EReaction.Trigger)
			game.SoundManager.PlaySound(SoundManager.ESound.eAgro);


		DoInTime(Evaluate, evaluateFrequency);
	}

	protected new float GetDistanceTo(Vector3 pPosition)
	{
		return movement.GetDistanceTo(pPosition);
	}

	private bool CheckTrueNews()
	{
		var trueNewsHit = Physics2D.CircleCastAll(transform.position, sightRange, Vector2.zero, 0, game.Layers.Item);
		foreach(var item in trueNewsHit)
		{
			TrueNews trueNews = item.transform.GetComponent<TrueNews>();
			if(trueNews)
			{
				//bubble.SetReaction(ECitizenReaction.What);
				targetPos = trueNews.GetPosition();
				game.SoundManager.PlaySound(SoundManager.ESound.eCitizenNews);

				return true;
			}
		}
		return false;
	}

	private bool CheckPlayer()
	{
		var playerHit = Physics2D.CircleCast(transform.position, sightRange, Vector2.zero, 0, game.Layers.Player);
		if(!playerHit)
			return false;

		Player player = playerHit.transform.GetComponent<Player>();
		//only target player if he is carrying a G
		bool hasG = player.Inventory.HasItem(EMapItem.GSource);
		if(!hasG)
			return false;

		bool isWearingHat = player.TinFoilHat.IsActive;
		if(isWearingHat)
			return false;

		attackTarget = playerHit.transform.GetComponent<Player>().Energy;
		attack = true;
		return true;
	}

	private void Idle()
	{
		//Debug.Log("Idle");
		idle = true;
		movement.Move(0, 0);
	}

	private bool WasBrodcastedRecently()
	{
		return lastTowerNoticed && Time.time - lastTimeBroadcasted < timeToForgetBroadcast;
	}

	float lastTimeBroadcasted;
	Tower lastTowerNoticed;

	internal void OnBroadcast(Tower pOrigin, float pSpeedDecrease)
	{
		//Debug.Log($"{transform.name} got broadcasted by {pOrigin.transform.name}. OUCH!");
		lastTowerNoticed = pOrigin;
		lastTimeBroadcasted = Time.time;

		AddSpeed(-pSpeedDecrease);

		SetColor(hitColor);
		DoInTime(() => SetColor(Color.white), 0.1f);
	}

	private void SetColor(Color pColor)
	{
		foreach(var bs in bodySprites)
		{
			bs.color = pColor;
		}
	}

	private void AddSpeed(float pValue)
	{
		movement.speed = Mathf.Clamp(movement.speed + pValue, MIN_SPEED, MAX_SPEED);
	}

	private void Attack(IDamageHandler pTarget)
	{
		Debug.Log("Attack " + pTarget);
		pTarget.OnReceivedDamage(damage);
	}
}
