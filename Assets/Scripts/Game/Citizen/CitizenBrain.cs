using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitizenBrain : GameBehaviour
{
	[SerializeField] PlayerMovement movement;
	[SerializeField] Transform target;
	[SerializeField] Vector3? targetPos;

	[SerializeField] float sightRange = 5;
	[SerializeField] float attackRange = 1;

	[SerializeField] float timeToForgetBroadcast = 5;


	[SerializeField] Transform debug_target;
	[SerializeField] bool debug_idle;

	bool idle;
	bool attack;

	private void Update()
	{
		if(debug_target)
			target = debug_target;
		if(target != null)
			targetPos = target.position;
		if(targetPos == null)
		{
			movement.Move(0, 0);
			return;
		}

		Vector3 targetPosition = (Vector3)targetPos;
		Vector3 dir = (targetPosition - transform.position).normalized;
		if(idle)
			return;
		if(attack && GetDistanceTo(targetPosition) < attackRange - DIST_OFFSET)
			return;
		if(GetDistanceTo(targetPosition) < DIST_OFFSET)
			return;

		//Debug.Log("Move " + dir);
		movement.Move(dir.x, dir.y);
	}

	[SerializeField] float evaluateFrequency = 1;

	private void Awake()
	{
		DoInTime(Evaluate, evaluateFrequency);
	}

	private void Evaluate()
	{
		//Debug.Log("Evaluate ");
		var playerHit = Physics2D.CircleCast(transform.position, sightRange, Vector2.zero, 0, game.Layers.Player);
		//todo: only if he has G

		target = null;
		targetPos = null;
		attack = false;
		idle = false;

		if(debug_idle)
			Idle();

		if(playerHit)
		{
			target = playerHit.transform;
			attack = true;
		}
		else if(WasBrodcastedRecently())
		{
			target = lastTowerNoticed.transform;
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

		if(attack && GetDistanceTo(target) < attackRange)
		{
			Attack(target);
		}

		DoInTime(Evaluate, evaluateFrequency);
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

	internal void OnBroadcast(Tower pOrigin)
	{
		Debug.Log($"{transform.name} got broadcasted by {pOrigin.transform.name}. OUCH!");
		lastTowerNoticed = pOrigin;
		lastTimeBroadcasted = Time.time;
	}

	private void Attack(Transform pTarget)
	{
		Debug.Log("Attack " + pTarget.name);
	}
}
