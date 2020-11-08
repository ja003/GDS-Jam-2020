using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : GameBehaviour
{
	[SerializeField] Image msg2;
	[SerializeField] Image msg3;
	[SerializeField] Image msg4;
	[SerializeField] Image msg5;

	[SerializeField] Button btnOk;

	int currentMsg = 1;

	[SerializeField] bool debug_StopIntro;

	private void Awake()
	{
		if(debug_StopIntro)
		{
			gameObject.SetActive(false);
			return;
		}

		Debug.LogError("TODO: hover icon");

		msg2.gameObject.SetActive(false);
		msg3.gameObject.SetActive(false);
		msg4.gameObject.SetActive(false);
		msg5.gameObject.SetActive(false);

		btnOk.onClick.AddListener(ShowNextMsg);
	}

	private void ShowNextMsg()
	{
		currentMsg++;
		if(currentMsg > 5)
		{
			Debug.Log("Lets play");
			gameObject.SetActive(false);
			return;
		}

		Image msg = GetMsg(currentMsg);
		msg.gameObject.SetActive(true);
	}

	private Image GetMsg(int currentMsg)
	{
		switch(currentMsg)
		{
			case 2:
				return msg2;
			case 3:
				return msg3;
			case 4:
				return msg4;
			case 5:
				return msg5;
		}

		return null;
	}
}
