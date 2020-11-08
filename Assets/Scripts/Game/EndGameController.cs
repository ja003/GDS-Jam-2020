using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : GameBehaviour
{
	List<Tower> towers = new List<Tower>();

	public bool GameEnded;

	private void Awake()
	{
		game.HUD.Curtain.SetFade(false, null, 3);
	}

	public void RegisterTower(Tower pTower)
	{
		towers.Add(pTower);
		pTower.OnUpgradeCompleteA += OnTowerUpgraded;
		Debug.Log($"RegisterTower = {pTower}/{towers.Count}");
	}

	private void OnTowerUpgraded()
	{
		int lvl5Towers = 0;
		foreach(Tower t in towers)
		{
			if(t.State.Level == 5)
				lvl5Towers++;
		}
		Debug.Log($"Towers = {lvl5Towers}/{towers.Count}");

		if(lvl5Towers == towers.Count)
		{
			EndGame(true);
		}
	}

	public void EndGame(bool pWin)
	{
		if(GameEnded)
		{
			Debug.Log("gamew already ended");
			return;
		}

		GameEnded = true;
		Debug.Log("WIN = " + pWin);

		SaveDataController.OnLevelWin(director.SelectedLevel);

		game.HUD.Curtain.SetFade(true, () => game.HUD.EndScreen.Show(pWin), 3);
	}

	//private void GoToMenu()
	//{
	//	SceneManager.LoadScene("Menu");
	//}
}
