using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : GameBehaviour
{
	private float timeStart;

	private void Awake()
	{
		timeStart = Time.time;
	}

	public float GetTimeLeft()
	{
		return timeStart + game.MapController.Region.Time - Time.time;
	}

	private void Update()
	{
		Debug.Log($"Time left = {GetTimeLeft()}");
	}
}
