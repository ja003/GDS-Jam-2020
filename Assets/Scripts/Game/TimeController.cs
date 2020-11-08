using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		float timeLeft = GetTimeLeft();

		if (timeLeft <= 0)
		{
			game.EndGame.EndGame(false);

			// TO DISPLAY 00:00 on the clock
			timeLeft = 0;
		}

		var ts = TimeSpan.FromSeconds(timeLeft);
		game.HUD.HudTimer.timeText.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);

		
	}
}
