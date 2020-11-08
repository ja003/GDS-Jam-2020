using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDataController 
{
    public static void OnLevelWin(int pLevel)
    {
		PlayerPrefs.SetInt(GetLevelKey(pLevel), 1);
	}

	public static bool IsLevelDone(int pLevel)
	{
		return PlayerPrefs.GetInt(GetLevelKey(pLevel)) > 0;
	}

	private static string GetLevelKey(int pLevel)
	{
		return "LEVEL_" + pLevel;
	}
}
