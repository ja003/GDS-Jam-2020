using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDebug : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	Player player => Game.Instance.Player;

#if UNITY_EDITOR
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			Time.timeScale += 0.5f;
			Debug.Log($"Time.timeScale = {Time.timeScale}");
		}
		if(Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			Time.timeScale -= 0.5f;
			Debug.Log($"Time.timeScale = {Time.timeScale}");
		}

		if(Input.GetKeyDown(KeyCode.T))
		{
			
			Game.Instance.ItemManager.UseItem(player, EMapItem.GSource);
		}
		if(Input.GetKeyDown(KeyCode.O))
		{
			var towers = FindObjectsOfType<Tower>();
			foreach(var t in towers)
			{
				t.debug_InstaUpgrade();
			}
		}
		if(Input.GetKeyDown(KeyCode.L))
		{
			var towers = FindObjectsOfType<Tower>();
			foreach(var t in towers)
			{
				t.OnReceivedDamage(10);
			}
		}



		if(Input.GetKeyDown(KeyCode.C))
		{
			Game.Instance.CitizenGenerator.SpawnCitizen();
		}

		if(Input.GetKeyDown(KeyCode.I))
		{
			player.Energy.AddEnergy(-10);
		}
	}
#endif
}
