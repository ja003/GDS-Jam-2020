using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : GameBehaviour
{
	[SerializeField] Text text;
	[SerializeField] Button btnExit;
	[SerializeField] Button btnNextLevel;
	[SerializeField] Button btnRetry;

	private void Awake()
	{
		btnExit.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
		btnNextLevel.onClick.AddListener(NextLevel);
		btnRetry.onClick.AddListener(() => SceneManager.LoadScene("Game"));
	}

	private void NextLevel()
	{
		director.SelectedLevel++;
		SceneManager.LoadScene("Game");
	}

	public void Show(bool pWin)
	{
		gameObject.SetActive(true);
		text.text = pWin ?
			"You have done it!\n:)))" :
			"You have failed\n:(" 
			;
		text.color = pWin ? Color.green : Color.red;
		btnNextLevel.gameObject.SetActive(pWin);
		btnRetry.gameObject.SetActive(!pWin);
	}
}
