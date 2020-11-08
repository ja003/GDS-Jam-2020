using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button btnStart;
	[SerializeField] Button btnExit;

	[SerializeField] LevelButton btnLevel1;
	[SerializeField] LevelButton btnLevel2;


	[SerializeField] List<GameObject> levelButtons;

	private void Awake()
    {
		btnStart.onClick.AddListener(() => StartCoroutine(OnBtnStart()));
		btnExit.onClick.AddListener(OnBtnExit);

		bool lvl1Done = SaveDataController.IsLevelDone(1);
		bool lvl2Done = SaveDataController.IsLevelDone(2);
		bool lvl3Done = SaveDataController.IsLevelDone(3);

		btnLevel1.SetEnabled(true);
		btnLevel2.SetEnabled(lvl1Done);

		btnLevel1.AddAction(() => SelectLevel(1));
		btnLevel2.AddAction(() => SelectLevel(2));
	}


	private void SelectLevel(int pLevel)
	{
		Debug.Log("SelectLevel " + pLevel);
		Director.Instance.SelectedLevel = pLevel;
		SceneManager.LoadScene("Game");
	}

	private IEnumerator OnBtnStart()
	{
		foreach(var lvlBtn in levelButtons)
		{
			lvlBtn.SetActive(true);
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void OnBtnExit()
	{
		Application.Quit();
	}

}
