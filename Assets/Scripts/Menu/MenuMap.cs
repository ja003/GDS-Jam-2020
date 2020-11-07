using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMap : MonoBehaviour
{
    [SerializeField]
    List<Button> regions;

    private void Awake()
    {
        Debug.Log("TODO: load map progress");
        regions[0].interactable = true; 
        regions[1].interactable = false;

        regions[0].onClick.AddListener(() => LoadRegion(0));

        //for(int i = 0; i < regions.Count; i++)
        //{
        //    regions[i].onClick.AddListener(() => LoadRegion(i));
        //}
    }

    private void LoadRegion(int pIndex)
    {
        int regionNumber = pIndex + 1;
        Debug.Log("LoadRegion " + regionNumber);
        Director.Instance.RegionIndex = pIndex;

        SceneManager.LoadScene("Game");
    }
}
