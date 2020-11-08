using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CSingletion("Singletons/P_Director", true)]
public class Director : CSingleton<Director>
{
	public int SelectedLevel { get; internal set; }
}
